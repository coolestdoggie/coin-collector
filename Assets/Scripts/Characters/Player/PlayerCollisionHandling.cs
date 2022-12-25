using System;
using CoinCollector.Characters.Flower;
using UnityEngine;

namespace CoinCollector.Characters.Player
{
    public class PlayerCollisionHandling : MonoBehaviour
    {
        public event Action CollidedWithFlower;

        private PlayerModel _playerModel;

        public void Init(PlayerModel playerModel)
        {
            _playerModel = playerModel;
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            var flowerView = other.GetComponent<FlowerView>();
            if (flowerView != null)
            {
                flowerView.Release();
                OnCollidedWithFlower();
            }
        }

        protected virtual void OnCollidedWithFlower()
        {
            CollidedWithFlower?.Invoke();
        }
    }
}