using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class sukoa : MonoBehaviour
{
    
    [SerializeField] Text scoretext;
    // Start is called before the first frame update
    void Start()
    {
        scoretext.text = "スコア" + 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ScoreView(int score)
    {
        scoretext.text = "スコア" + score;
    }
}
