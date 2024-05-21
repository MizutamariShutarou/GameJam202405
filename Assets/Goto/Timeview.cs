using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timeview : MonoBehaviour
{
  
    [SerializeField] Text timeviw;
    [SerializeField] float time = 60f;

    [SerializeField] GameObject panel;

    private bool _isRunning = false;
    // Start is called before the first frame update
    void Start()
    {
        _isRunning = true;
        timeviw.text = time.ToString();
        
        if(panel == null) return;
        panel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(!_isRunning) return;
        
        time -= Time.deltaTime;
        timeviw.text = time.ToString("0.00");

        if (time <= 0)
        {
            time = 0;
            _isRunning = false;
            
            if(panel == null) return;
            panel.SetActive(true);
        }

    }
}
