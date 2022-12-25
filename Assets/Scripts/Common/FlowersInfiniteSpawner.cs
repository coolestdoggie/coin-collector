using System.Threading.Tasks;
using CoinCollector.Characters;
using CoinCollector.Characters.Flower;
using CoinCollector.Utils;
using UnityEngine;

namespace CoinCollector.Common
{
    public class FlowersInfiniteSpawner : IInfiniteSpawner 
    {
        private ObjectPool<FlowerView> _flowerViewsPool;

        private ICharactersFactory _charactersFactory;

        private bool _isSpawning;

        public FlowersInfiniteSpawner(ICharactersFactory charactersFactory)
        {
            _charactersFactory = charactersFactory;
            
            _flowerViewsPool = new ObjectPool<FlowerView>(
                ViewCreate,
                ViewOnGet,
                ViewOnRelease,
                10,
                false
            );
        }

        public void StartInfiniteSpawn()
        {
            _isSpawning = true;
            InfiniteSpawn();
        }

        private async void InfiniteSpawn()
        {
            while (_isSpawning)
            {
                SpawnInstance();
                await Task.Delay(3000);
            }
        }

        public void SpawnInstance()
        {
            _flowerViewsPool.Get();
        }

        public void StopInfiniteSpawn()
        {
            _isSpawning = false;
        }

        private FlowerView ViewCreate()
        {
            GameObject flower = _charactersFactory.Create(CharacterType.Flower, Vector2.zero);
            FlowerView flowerView = flower.GetComponent<FlowerView>();
            
            return flowerView;
        }

        private void ViewOnGet(FlowerView obj)
        {
            if (obj == null)
            {
                return;
            }
            
            obj.gameObject.SetActive(true);
            RandomizePosition(obj);
            
            FlowerView flowerView = obj.GetComponent<FlowerView>();
            flowerView.SetPool(_flowerViewsPool);
        }

        private void RandomizePosition(FlowerView flowerView)
        {
            float randomX = Random.Range(-5, 5);
            float randomY = Random.Range(-5, 5);
            
            flowerView.gameObject.transform.position = new Vector2(randomX, randomY);
        }

        private void ViewOnRelease(FlowerView obj)
        {
            obj.gameObject.SetActive(false);
        }
    }
}