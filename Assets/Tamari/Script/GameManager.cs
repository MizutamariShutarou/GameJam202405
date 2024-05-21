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
    
    [SerializeField] GameObject _panel;
    
    private ReactiveProperty<PlayerState> _playerState = new ReactiveProperty<PlayerState>();

    public ReactiveProperty<PlayerState> State => _playerState;

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
        _playerState.Value = PlayerState.Alive;
        Bind();
    }

    private void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            ScoreManager.Instance.AddScore(100);
        }
    }

    /// <summary>
    /// 登録処理
    /// </summary>
    private void Bind()
    {
        _playerState.Subscribe(state =>
        {
            if (state == PlayerState.Alive)
            {
                _panel.SetActive(false);
            }
            if (state == PlayerState.Finish)
            {
                ScoreManager.Instance.StopAddScore(); 
                TimerManager.Instance.StopTimer();
                _panel.SetActive(true);      
            }
        }).AddTo(this);
    }
}
