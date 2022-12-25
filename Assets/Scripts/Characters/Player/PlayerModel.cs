using System;

namespace CoinCollector.Characters.Player
{
    public class PlayerModel
    {
        public MoveData MoveData { get; }
        public PhysicsData PhysicsData { get; }
        public StateData StateData { get; }

        public event Action CollectedFlower;
        
        public PlayerModel()
        {
            MoveData = new MoveData();
            PhysicsData = new PhysicsData();
            StateData = new StateData();
        }

        public void OnCollectedFlower()
        {
            CollectedFlower?.Invoke();
        }
    }
}