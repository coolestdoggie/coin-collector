using CoinCollector.Common;
using CoinCollector.Common.RemoteConfig;
using UnityEngine;

namespace CoinCollector.Characters.Player
{
    public class PhysicsData
    {
        public LayerMask LayerMask { get; } = LayerMask.NameToLayer(ConfigValues.PLAYER_LAYER_MASK);
    }
}