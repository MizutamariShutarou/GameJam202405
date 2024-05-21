using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{

    private void OnTriggerStay2D(Collider2D collision)
    {
        Debug.Log("Hit");
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("クリックされた");
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("スペースが押された");
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            Debug.Log("Aが押された");
            
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            Debug.Log("Dが押された");
        }
    }
}
