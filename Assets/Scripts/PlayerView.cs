using UnityEngine;

public class PlayerView : MonoBehaviour
{
    [SerializeField] private PlayerMovement _playerMovement;
    private PlayerInput _playerInput;
    private PlayerModel _playerModel;

    public void Init(PlayerModel playerModel)
    {
        _playerModel = playerModel;
        _playerInput = new PlayerInput();
        _playerMovement.Init(_playerModel);

        _playerInput.UserTapped += _playerMovement.StartMovement;
    }

    private void OnDestroy()
    {
        _playerInput.UserTapped -= _playerMovement.StartMovement;
    }
}