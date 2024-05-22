using System;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.SocialPlatforms.Impl;

public class GameManager : MonoBehaviour
{
    [SerializeField] private PlayerScript _player = default;

    [SerializeField] private SpawnEnemy _spawner = default;
    
    [SerializeField] GameObject _panel = default;
    
    private ReactiveProperty<InGameState> _playerState = new ReactiveProperty<InGameState>();

    public ReactiveProperty<InGameState> State => _playerState;

    private static GameManager _instance = default;

    public static GameManager Instance => _instance;

    private void Awake()
    {
        _instance = this;
    }

    private void Start()
    {
        Initialize();
    }

    /// <summary>
    /// 初期化
    /// </summary>
    private void Initialize()
    {
        _playerState.Value = InGameState.Start;
        Bind();
    }

    /// <summary>
    /// 登録処理
    /// </summary>
    private void Bind()
    {
        _playerState.Subscribe(state =>
        {
            if (state == InGameState.Start)
            {
                ScoreManager.Instance.StartAddScore(); 
                TimerManager.Instance.StartTimer();
                _spawner.SetSpawner(true);
                _panel.SetActive(false);
            }
            if (state == InGameState.Finish)
            {
                _spawner.SetSpawner(false);
                ScoreManager.Instance.StopAddScore(); 
                TimerManager.Instance.StopTimer();
                _panel.SetActive(true);      
            }
        }).AddTo(this);
    }
}
