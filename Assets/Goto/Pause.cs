using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pause : MonoBehaviour
{
    bool ispose = false;

    [SerializeField] GameObject pausepanel;
    // Start is called before the first frame update
    void Start()
    {
        pausepanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

        if (ispose == false && Input.GetKeyDown(KeyCode.Escape))
        {
            ispose = true;
            Time.timeScale = 0;

            pausepanel.SetActive(true);
            // panel表示

            return;
        }


        if (ispose == true && Input.GetKeyDown(KeyCode.Escape))
        {
            ispose = false;
            Time.timeScale = 1;

            // panel非表示
            pausepanel.SetActive(false);

            return;
        }


    }
}
