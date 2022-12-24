using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerView : MonoBehaviour
{
    private PlayerModel _playerModel;
    
    private PlayerInput _playerInput;
    private PlayerInputActions _playerInputActions;
    private Vector2 _targetPosition;

    public void Init(PlayerModel playerModel)
    {
        _playerModel = playerModel;
        
        _playerInput = GetComponent<PlayerInput>();
        _playerInputActions = new PlayerInputActions();
        _playerInputActions.Enable();
        _playerInputActions.Player.Tap.performed += StartMovement;
    }

    private void StartMovement(InputAction.CallbackContext callbackContext)
    {
        StartCoroutine(MoveCoroutine());
    }
    
    private IEnumerator MoveCoroutine()
    {
        _targetPosition = Camera.main.ScreenToWorldPoint(_playerInputActions.Player.Position.ReadValue<Vector2>());
        
        bool needToMove = true;
        while (needToMove)
        {
            needToMove = Move();
            yield return new WaitForEndOfFrame();
        }
    }

    private bool Move()
    {
        float step = _playerModel.MoveData.Speed * Time.deltaTime;

        transform.position = Vector2.MoveTowards(transform.position, _targetPosition, step);
        
        if (Vector3.Distance(transform.position, _targetPosition) < Mathf.Epsilon)
        {
            transform.position = _targetPosition;
            return false;
        }

        return true;
    }
    
    
    
}