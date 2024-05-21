using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class Timeview : MonoBehaviour
{
    [SerializeField] Text timeText;

    // Start is called before the first frame update
    void Start()
    {
        timeText.text = TimerManager.Instance.Timer.ToString();
    }
    
    public void TimerView(float time)
    {
        timeText.text = time.ToString("0.00");
    }
}
