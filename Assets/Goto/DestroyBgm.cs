using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBgm : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameObject obj = GameObject.Find("OutgeamBgm");
        Destroy(obj);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
