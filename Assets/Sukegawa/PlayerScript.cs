﻿using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerScript : MonoBehaviour
{
    EnemyStatus _enemy = default;

    Rigidbody2D _p_move = default;

    SpriteRenderer _spriteRenderer;

    int _jumpSpeed = 15;

    public string _groundTag = "Ground";

    public bool _checkGround = true;

    private bool _canJump = true;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            _enemy = collision.GetComponent<EnemyStatus>();
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
        _spriteRenderer = GetComponent<SpriteRenderer>();
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
            if (_canJump)
            {
                _p_move.AddForce(Vector2.up * _jumpSpeed, ForceMode2D.Impulse);
                _canJump = !_checkGround;
            }

        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            transform.localScale = new Vector3(-1 * Mathf.Abs(this.transform.localScale.x), this.transform.localScale.y, this.transform.localScale.z);
            //_spriteRenderer.flipX = true;
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            transform.localScale = new Vector3(Mathf.Abs(this.transform.localScale.x), this.transform.localScale.y, this.transform.localScale.z);
            //_spriteRenderer.flipX = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collisionData)
    {
        if (_checkGround
            && collisionData.gameObject.CompareTag(_groundTag))
        {
            _canJump = true;
        }
    }
}