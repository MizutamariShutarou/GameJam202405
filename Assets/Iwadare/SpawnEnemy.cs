using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    [SerializeField] MovePatternState _currentState;
    [SerializeField] RbMovePattern[] _RbMovePattern;
    [SerializeField] EnemyStatus[] _rbEnemy;
    // Start is called before the first frame update
    void Start()
    {
        int number = 0;
        for (var i = 0; i < _RbMovePattern.Length; i++)
        {
            if(_currentState == _RbMovePattern[i].State)
            {
                number = i;
                break;
            }
        }
        var randomObj = UnityEngine.Random.Range(0, _rbEnemy.Length);
        var enemy = Instantiate(_rbEnemy[randomObj], _RbMovePattern[number]._spawnPoint.position, Quaternion.identity);
        enemy.ObjectMove(_RbMovePattern[number]._horizontalSpeed, _RbMovePattern[number]._verticalSpeed);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    enum MovePatternState
    {
        Forward,
        ForwardUp,
        BackYard,
        BackYardUp,
    }

    [Serializable]
    struct RbMovePattern
    {
        public MovePatternState State;
        public Transform _spawnPoint;
        public float _horizontalSpeed;
        public float _verticalSpeed;
    }
}
