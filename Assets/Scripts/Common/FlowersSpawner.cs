using CoinCollector.Characters;
using CoinCollector.Characters.Flower;
using CoinCollector.Utils;
using UnityEngine;

namespace CoinCollector.Common
{
    public class FlowersSpawner : ISpawner
    {
        private ObjectPool<FlowerView> _flowerViewsPool;
        private ICharactersFactory _charactersFactory;
        public FlowersSpawner(ICharactersFactory charactersFactory)
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

        private FlowerView ViewCreate()
        {
            GameObject flower = _charactersFactory.Create(CharacterType.Flower, Vector2.zero);
            FlowerView flowerView = flower.GetComponent<FlowerView>();
            return flowerView;
        }
        
        private void ViewOnGet(FlowerView obj)
        {
            obj.gameObject.SetActive(true);
        }
        
        private void ViewOnRelease(FlowerView obj)
        {
            obj.gameObject.SetActive(false);
        }

        public void SpawnOneObject()
        {
            _flowerViewsPool.Get();
        }
    }
}