using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.UI;

public class TimerManager : MonoBehaviour
{
    [SerializeField] float _timer = 60f;
    public float Timer => _timer;

    [SerializeField] Timeview _timeView;
    public static TimerManager Instance;

    private bool _isRunning = false;

    void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        _isRunning = true;
    }

    void Update()
    {
        if (!_isRunning) return;
        
        if (_timer <= 0)
        {
            _timer = 0;
            _isRunning = false;
            GameManager.Instance.State.Value = PlayerState.Finish;
        }

        _timer -= Time.deltaTime;
        _timeView.TimerView(_timer);
    }

    public void ChangeTime(float time)
    {
        _timer += time;
        if (_timer <= 0)
        {
            StopTimer();
        }
    }

    public void StopTimer()
    {
        _timer = 0;
        _timeView.TimerView(_timer);
    }
}