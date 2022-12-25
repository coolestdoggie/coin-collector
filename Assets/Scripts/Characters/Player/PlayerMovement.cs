using CoinCollector.Common;
using UnityEngine;
using Zenject;

namespace CoinCollector.Characters.Player
{
    public class PlayerMovement : MonoBehaviour
    {
        private PlayerModel _playerModel;
        private IStats _stats;

        [Inject]
        private void Construct(IStats stats)
        {
            _stats = stats;
        }
    
        public void Init(PlayerModel playerModel)
        {
            _playerModel = playerModel;
        }

        public void StartMovement(Vector2 posToMove)
        {
            _playerModel.StateData.TargetPosition = posToMove;
            _playerModel.StateData.IsMoving = true;
        }

        public void StopMovement()
        {
            _playerModel.StateData.IsMoving = false;
        }
    
        private void Update()
        {
            MoveProcess();
        }

        private void MoveProcess()
        {
            if (!_playerModel.StateData.IsMoving) return;

            Move();
        }

        private void Move()
        {
            _playerModel.StateData.PosLastMovementFrame = transform.position;
            
            float step = _playerModel.MoveData.Speed * Time.deltaTime;
            transform.position = 
                Vector2.MoveTowards(transform.position, _playerModel.StateData.TargetPosition, step);

            Vector2 deltaLastFrame = _playerModel.StateData.PosLastMovementFrame - (Vector2) transform.position;
            _stats.TraveledDistance += deltaLastFrame.magnitude;

            if (!IsOnTarget()) return;
        
            transform.position = _playerModel.StateData.TargetPosition;
            StopMovement();
        }

        private bool IsOnTarget()
        {
            return Vector3.Distance(transform.position, _playerModel.StateData.TargetPosition) < Mathf.Epsilon;
        }
    }
}