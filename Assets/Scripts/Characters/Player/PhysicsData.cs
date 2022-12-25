using UnityEngine;

namespace CoinCollector.Characters.Player
{
    public class PhysicsData
    {
        public LayerMask LayerMask { get; } = LayerMask.NameToLayer("Player");
    }
}