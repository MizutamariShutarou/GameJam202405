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

    [SerializeField] GameObject panel;

    private bool _isRunning = false;

    void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        _isRunning = true;

        if (panel == null) return;
        panel.SetActive(false);
    }

    void Update()
    {
        if (_timer <= 0)
        {
            _timer = 0;
            _isRunning = false;
            panel.SetActive(true);
        }

        if (!_isRunning) return;

        _timer -= Time.deltaTime;
        _timeView.TimerView(_timer);
    }

    public void ChangeTime(float time)
    {
        _timer += time;
        if (_timer <= 0)
        {
            ResetTimer();
        }
    }

    public void ResetTimer()
    {
        _timer = 0;
        _timeView.TimerView(_timer);
    }
}