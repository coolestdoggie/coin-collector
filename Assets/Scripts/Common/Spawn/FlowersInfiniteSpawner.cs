using System.Threading.Tasks;
using CoinCollector.Characters;
using CoinCollector.Characters.Flower;
using CoinCollector.Common.RemoteConfig;
using CoinCollector.Utils;
using UnityEngine;

namespace CoinCollector.Common.Spawn
{
    public class FlowersInfiniteSpawner : IInfiniteSpawner 
    {
        private ObjectPool<FlowerView> _flowerViewsPool;
        private ICharactersFactory _charactersFactory;
        private FlowersSpawnerStateData _spawnerStateData;
        
        public FlowersInfiniteSpawner(ICharactersFactory charactersFactory)
        {
            _charactersFactory = charactersFactory;
            _spawnerStateData = new FlowersSpawnerStateData();
            
            _flowerViewsPool = new ObjectPool<FlowerView>(
                ViewCreate,
                ViewOnGet,
                ViewOnRelease,
                ConfigValues.MAX_AMOUNT_OF_FLOWERS,
                false
            );
        }

        public void StartInfiniteSpawn()
        {
            _spawnerStateData.IsSpawning= true;
            InfiniteSpawn();
        }

        private async void InfiniteSpawn()
        {
            while (_spawnerStateData.IsSpawning)
            {
                SpawnInstance();
                await Task.Delay(ConfigValues.MS_BTW_FLOWERS_SPAWN);
            }
        }

        public void SpawnInstance()
        {
            _flowerViewsPool.Get();
        }

        public void StopInfiniteSpawn()
        {
            _spawnerStateData.IsSpawning = false;
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
            Vector2 xBounds = Utils.Utils.GetXWorldBounds();
            Vector2 yBounds = Utils.Utils.GetYWorldBounds();
            
            float randomX = Random.Range(xBounds.x, xBounds.y);
            float randomY = Random.Range(yBounds.x, yBounds.y);
            
            flowerView.gameObject.transform.position = new Vector2(randomX, randomY);
        }

        private void ViewOnRelease(FlowerView obj)
        {
            obj.gameObject.SetActive(false);
        }
    }
}