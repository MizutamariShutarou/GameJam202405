using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyWaterMelon : MonoBehaviour
{
    Rigidbody2D _rb;
    [SerializeField] float _speed;
    public bool _cut;
    //[SerializeField] Animator _animObject;
    
    
    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        if(_rb)_rb.velocity = Vector3.left * _speed;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Cut()
    {
        _cut = true;
        Debug.Log("切られた");
    }
}
