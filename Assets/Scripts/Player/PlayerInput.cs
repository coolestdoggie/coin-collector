using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace CoinCollector.Player
{
    public class PlayerInput
    {
        private readonly PlayerInputActions _playerInputActions;
        private PhysicsData _playerPhysicsData;

        public event Action<Vector2> UserTapped;
        public event Action UserTappedOnPlayer;

        public PlayerInput(PhysicsData playerPhysicsData)
        {
            _playerPhysicsData = playerPhysicsData;
            _playerInputActions = new PlayerInputActions();
            _playerInputActions.Enable();
            _playerInputActions.Player.Tap.performed += OnUserTapped;
        }

        protected virtual void OnUserTapped(InputAction.CallbackContext callbackContext)
        {
            Vector2 tapInScreenCoords = _playerInputActions.Player.Position.ReadValue<Vector2>();
            Vector2 tapPosInWorldCoords = Camera.main.ScreenToWorldPoint(tapInScreenCoords);
        
            UserTapped?.Invoke(tapPosInWorldCoords);
        
            CheckOnPlayerTap(tapPosInWorldCoords);
        }

        private void CheckOnPlayerTap(Vector2 tapPosInWorldCoords)
        {
            RaycastHit2D hit = Physics2D.Raycast(tapPosInWorldCoords, Vector2.zero, Mathf.Infinity,
                1 << _playerPhysicsData.LayerMask);
            if (hit.collider != null)
            {
                OnUserTappedOnPlayer();
            }
        }

        protected virtual void OnUserTappedOnPlayer()
        {
            UserTappedOnPlayer?.Invoke();
        }

        ~PlayerInput()
        {
            _playerInputActions.Player.Tap.performed -= OnUserTapped;
        }
    }
}