using UnityEngine;

namespace CoinCollector.Player
{
    public class PhysicsData
    {
        public LayerMask LayerMask { get; } = LayerMask.NameToLayer("Player");
    }
}