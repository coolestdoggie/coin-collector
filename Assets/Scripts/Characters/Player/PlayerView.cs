using UnityEngine;

namespace CoinCollector.Characters.Player
{
    public class PlayerView : MonoBehaviour
    {
        [SerializeField] private PlayerMovement _playerMovement;
        [SerializeField] private PlayerCollisionHandling _playerCollisionHandling;
        private PlayerInput _playerInput;
        private PlayerModel _playerModel;

        public void Init(PlayerModel playerModel)
        {
            _playerModel = playerModel;
            _playerInput = new PlayerInput(playerModel.PhysicsData);
            _playerMovement.Init(_playerModel);

            _playerInput.UserTapped += _playerMovement.StartMovement;
            _playerInput.UserTappedOnPlayer += _playerMovement.StopMovement;
        }

        private void OnDestroy()
        {
            _playerInput.UserTapped -= _playerMovement.StartMovement;
            _playerInput.UserTappedOnPlayer -= _playerMovement.StopMovement;
        }
    }
}