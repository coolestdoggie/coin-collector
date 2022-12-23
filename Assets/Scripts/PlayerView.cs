using System;
using System.Timers;
using UnityEngine;

public class PlayerView : MonoBehaviour
{
    private PlayerModel _playerModel;
    
    public void Init(PlayerModel playerModel)
    {
        _playerModel = playerModel;
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        float step = _playerModel.MoveData.Speed * Time.deltaTime;

        transform.position = Vector2.MoveTowards(transform.position, new Vector2(100, 100), step);
    }
}