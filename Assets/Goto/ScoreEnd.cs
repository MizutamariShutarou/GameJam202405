using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using UnityEngine;
using UnityEngine.UI;

public class ScoreEnd : MonoBehaviour
{
    private Text finishscore;
    // Start is called before the first frame update
    void Start()
    {
        finishscore = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        finishscore.text = ScoreManager.Instance.Score.ToString();    
    }
}
