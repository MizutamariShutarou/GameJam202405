using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    [SerializeField] MovePatternState _currentState;
    [SerializeField] MovePattern[] _movePattern;
    [SerializeField] EnemyStatus _enemy;
    // Start is called before the first frame update
    void Start()
    {
        int number = 0;
        for (var i = 0; i < _movePattern.Length; i++)
        {
            if(_currentState == _movePattern[i].State)
            {
                number = i;
                break;
            }
        }
        _enemy = Instantiate(_enemy, _movePattern[number]._spawnPoint.position, Quaternion.identity);
        _enemy.ObjectMove(_movePattern[number]._horizontalSpeed, _movePattern[number]._verticalSpeed);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    enum MovePatternState
    {
        Forward,
        ForwardUp,
        BackWard,
        Up,
    }

    [Serializable]
    struct MovePattern
    {
        public MovePatternState State;
        public Transform _spawnPoint;
        public float _horizontalSpeed;
        public float _verticalSpeed;
    }
}
