using UnityEngine;

namespace CoinCollector.Characters.Player
{
    public class StateData
    {
        public Vector2 TargetPosition { get; set; }
        public Vector2 PosLastMovementFrame { get; set; }
        public bool IsMoving { get; set; }
    }
}