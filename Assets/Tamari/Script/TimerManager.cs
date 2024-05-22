using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class TimerManager : MonoBehaviour
{
    [SerializeField] float _limitTimer = 60f;
    public float LimitTimer => _limitTimer;

    [SerializeField] Timeview _timeView;
    public static TimerManager Instance;

    private float _currentTime = 0f;
    public float CurrentTime => _currentTime;
    private bool _isRunning = false;

    void Awake()
    {
        Instance = this;
    }

    void Update()
    {
        if (!_isRunning) return;

        _currentTime -= Time.deltaTime;
        _timeView.TimerView(_currentTime);

        if (_currentTime <= 0)
        {
            StopTimer();
        }
    }

    public void ChangeTime(float time)
    {
        _currentTime += time;
        if (_currentTime <= 0)
        {
            StopTimer();
        }
    }

    public void StartTimer()
    {
        _isRunning = true;
        _currentTime = _limitTimer;
    }

    public void StopTimer()
    {
        _currentTime = 0;
        _timeView.TimerView(_currentTime);
        _isRunning = false;
        GameManager.Instance.State.Value = InGameState.Finish;
    }
}