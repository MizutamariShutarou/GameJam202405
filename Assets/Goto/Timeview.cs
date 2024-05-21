using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timeview : MonoBehaviour
{
   [SerializeField] Text timeviw;
   [SerializeField] float time = 60f;
    // Start is called before the first frame update
    void Start()
    {
       timeviw.text = time.ToString("d2");
    }

    // Update is called once per frame
    void Update()
    {
        time -= Time.deltaTime;
        timeviw.text = time.ToString("0.00");

        if (time <= 0)
        {
            time = 0;
        }

    }
}
