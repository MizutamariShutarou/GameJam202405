using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    int _score;

    [SerializeField] Scoreview _scoreView;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddScore(int score)
    {
        _score += score;
        _scoreView.ScoreView(_score);
    }
}
