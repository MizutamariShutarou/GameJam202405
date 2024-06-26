﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    [SerializeField] MovePattern[] _rbMovePattern;
    [SerializeField] MovePattern[] _notGravityMovePattern;
    [SerializeField] EnemyStatus[] _enemys;
    
    float _spawnCoolTime = 2f;
    [Header("最大スポーン時間")]
    [SerializeField] float _maxspawnCoolTime = 2f;
    [Header("最低スポーン時間")]
    [SerializeField] float _minspawnCoolTime = 1f;
    float _differenceCoolTime;
    float _currentCoolTime = 0f;
    [Header("スポーン時間を短縮するかしないか")]
    [SerializeField] bool _shortSpawn = true;
    private bool _isRunning = false;
    // Start is called before the first frame update
    void Start()
    {
        _spawnCoolTime = _maxspawnCoolTime;
        _differenceCoolTime = _maxspawnCoolTime - _minspawnCoolTime;
    }

    // Update is called once per frame
    void Update()
    {
        if(!_isRunning) return;
        
        _currentCoolTime += Time.deltaTime;

        if(_currentCoolTime < _spawnCoolTime) { return; }

        _currentCoolTime = 0f;
        if(_shortSpawn) 
        {
            var differenceTimer = TimerManager.Instance.CurrentTime / TimerManager.Instance.LimitTimer ;
            _spawnCoolTime = _minspawnCoolTime + (_differenceCoolTime * differenceTimer);
            Debug.Log(_spawnCoolTime);
        }

        var randomObj = UnityEngine.Random.Range(0, _enemys.Length);
        if (_enemys[randomObj]._isGravityScale)
        {
            var moveNumber = UnityEngine.Random.Range(0, _rbMovePattern.Length);

            var enemy = Instantiate(_enemys[randomObj], _rbMovePattern[moveNumber]._spawnPoint.position, Quaternion.identity);
            enemy.ObjectMove(_rbMovePattern[moveNumber]._horizontalSpeed, _rbMovePattern[moveNumber]._verticalSpeed);
        }
        else
        {
            var moveNumber = UnityEngine.Random.Range(0, _notGravityMovePattern.Length);

            var enemy = Instantiate(_enemys[randomObj], _notGravityMovePattern[moveNumber]._spawnPoint.position, Quaternion.identity);
            enemy.ObjectMove(_notGravityMovePattern[moveNumber]._horizontalSpeed, _notGravityMovePattern[moveNumber]._verticalSpeed);
        }
    }

    public void SetSpawner(bool isRunning)
    {
        _isRunning = isRunning;
    }

    enum MovePatternState
    {
        Forward,
        ForwardUp,
        BackYard,
        BackYardUp,
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
