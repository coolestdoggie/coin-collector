using System;
using UnityEngine.InputSystem;

public class PlayerInput
{
    private readonly PlayerInputActions _playerInputActions;

    public event Action<PlayerInputActions> UserTapped;

    public PlayerInput()
    {
        _playerInputActions = new PlayerInputActions();
        _playerInputActions.Enable();
        _playerInputActions.Player.Tap.performed += OnUserTapped;
    }

    protected virtual void OnUserTapped(InputAction.CallbackContext callbackContext)
    {
        UserTapped?.Invoke(_playerInputActions);
    }

    ~PlayerInput()
    {
        _playerInputActions.Player.Tap.performed -= OnUserTapped;
    }
}