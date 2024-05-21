using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    int _score;
    public int Score => _score;
    [SerializeField] Scoreview _scoreView;
    public static ScoreManager Instance;

    private bool _isRunnning = false;

    // Start is called before the first frame update
    void Awake()
    {
        Instance = this;
        _isRunnning = true;
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void AddScore(int score)
    {
        if (_isRunnning)
        {
            _score += score;
            _scoreView.ScoreView(_score);
        }
    }

    public void StopAddScore()
    {
        _isRunnning = false;
    }
}