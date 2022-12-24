using System.Collections;
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
        StartCoroutine(MoveCoroutine(playerInputActions));
    }

    private IEnumerator MoveCoroutine(PlayerInputActions playerInputActions)
    {
        _playerModel.StateData.TargetPosition = Camera.main.ScreenToWorldPoint(playerInputActions.Player.Position.ReadValue<Vector2>());
        
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

        transform.position = Vector2.MoveTowards(transform.position, _playerModel.StateData.TargetPosition, step);
        
        if (Vector3.Distance(transform.position, _playerModel.StateData.TargetPosition) < Mathf.Epsilon)
        {
            transform.position = _playerModel.StateData.TargetPosition;
            return false;
        }

        return true;
    }
}