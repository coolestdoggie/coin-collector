using CoinCollector.Utils;
using UnityEngine;

namespace CoinCollector.Characters.Flower
{
    public class FlowerView : MonoBehaviour
    {
        private ObjectPool<FlowerView> _flowerViewsPool;
        
        public void Init()
        {
        }

        public void SetPool(ObjectPool<FlowerView> flowerViewsPool)
        {
            _flowerViewsPool = flowerViewsPool;
        }

        public void Release()
        {
            _flowerViewsPool.Release(this);
            _flowerViewsPool = null;
        }
    }
}