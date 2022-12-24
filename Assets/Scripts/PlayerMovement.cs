using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private PlayerModel _playerModel;
    
    public void Init(PlayerModel playerModel)
    {
        _playerModel = playerModel;
    }

    public void StartMovement(PlayerInputActions playerInputActions)
    {
        _playerModel.StateData.TargetPosition = Camera.main.ScreenToWorldPoint(playerInputActions.Player.Position.ReadValue<Vector2>());
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
        if (!_playerModel.StateData.IsMoving)
        {
            return;
        }

        Move();
    }

    private void Move()
    {
        float step = _playerModel.MoveData.Speed * Time.deltaTime;
        transform.position = 
            Vector2.MoveTowards(transform.position, _playerModel.StateData.TargetPosition, step);

        if (!IsOnTarget()) return;
        
        transform.position = _playerModel.StateData.TargetPosition;
        StopMovement();
    }

    private bool IsOnTarget()
    {
        return Vector3.Distance(transform.position, _playerModel.StateData.TargetPosition) < Mathf.Epsilon;
    }
}