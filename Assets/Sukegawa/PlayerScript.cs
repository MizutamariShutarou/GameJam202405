using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerScript : MonoBehaviour
{
    EnemyWaterMelon _enemy = default;

    Rigidbody2D _p_move = default;

    int jumpSpeed = 15;

    bool facingleft = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            _enemy = collision.GetComponent<EnemyWaterMelon>();
            Debug.Log("Hit");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            _enemy = null;
        }

    }
    // Start is called before the first frame update
    void Start()
    {
        _p_move = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (_enemy == null)
            {
                Debug.Log("クリックされた");
            }

            if (_enemy != null)
            {
                _enemy.Cut();
            }
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("スペースが押された");
            _p_move.AddForce(Vector2.up * jumpSpeed, ForceMode2D.Impulse);
            
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            Debug.Log("Aが押された");
            transform.localScale = new Vector3(-1 * Mathf.Abs(this.transform.localScale.x), this.transform.localScale.y, this.transform.localScale.z);
            facingleft = true;

        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            Debug.Log("Dが押された");
            transform.localScale = new Vector3(Mathf.Abs(this.transform.localScale.x), this.transform.localScale.y, this.transform.localScale.z);
            facingleft = false;
        }
    }
}
