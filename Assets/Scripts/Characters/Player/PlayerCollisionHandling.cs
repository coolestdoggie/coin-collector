using System;
using CoinCollector.Characters.Flower;
using CoinCollector.Common;
using CoinCollector.Common.Stats;
using UnityEngine;
using Zenject;

namespace CoinCollector.Characters.Player
{
    public class PlayerCollisionHandling : MonoBehaviour
    {
        private PlayerModel _playerModel;
        private IStats _stats;

        [Inject]
        public void Construct(IStats stats)
        {
            _stats = stats;
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            var flowerView = other.GetComponent<FlowerView>();
            if (flowerView == null) return;
            
            flowerView.Release();
            _stats.Score++;
        }
    }
}