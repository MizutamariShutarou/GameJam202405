using DG.Tweening;
using System;
using System.Collections;
using UnityEngine;

public abstract class EnemyStatus : MonoBehaviour, ItemInterface
{
    Rigidbody2D _rb;
    [SerializeField] float _horizontalValue = 1f;
    [SerializeField] float _verticalValue = 1f;
    [NonSerialized] public bool _cut;
    public Animator _animObject;
    public bool _isGravityScale = true;
    [SerializeField] float _destroyTime = 5f;
    [SerializeField] float _cutDestroyTime = 1f;
    [SerializeField] bool _debug = false;



    // Start is called before the first frame update
    void Start()
    {
        if (_debug) ObjectMove(_horizontalValue, _verticalValue);
        Destroy(this.gameObject, _destroyTime);
    }

    // Update is called once per frame
    void Update()
    {

    }

    /// <summary>切った時の処理</summary>
    public void Cut()
    {
        if (_cut) { return; }
        _cut = true;
        Debug.Log("切られた");
        RodHitEvent();
    }

    /// <summary>オブジェクトを動かすときの処理(派生クラスにオーバーライド可能)</summary>
    /// <param name="horizontal"></param>
    /// <param name="vertical"></param>
    public virtual void ObjectMove(float horizontal, float vertical)
    {
        FlipX(horizontal);
        _rb = GetComponent<Rigidbody2D>();
        if (_rb)
        {
            if (_isGravityScale)
            {
                _rb.gravityScale = 1;
                _rb.AddForce(Vector2.left * horizontal * _horizontalValue +
                    Vector2.up * vertical * _verticalValue,
                    ForceMode2D.Impulse);
            }
            else
            {
                _rb.gravityScale = 0;
                _rb.velocity = Vector2.left * horizontal * _horizontalValue + Vector2.up * vertical * _verticalValue;
            }
        }
    }

    void FlipX(float horizontal)
    {
        if (horizontal < 0)
        {
            var scale = transform.localScale;
            scale.x *= -scale.x;
            transform.localScale = scale;
        }
    }

    /// <summary>プレイヤーに当たった時の処理</summary>
    public abstract void PlayerHitEvent();

    /// <summary>棒に当たった時の処理</summary>
    public abstract void RodHitEvent();

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (_cut) { return; }
        if (collision.TryGetComponent<PlayerScript>(out var player))
        {
            _cut = true;
            Debug.Log("当たった");
            PlayerHitEvent();
        }
    }

    public IEnumerator EnemyDestroyTime()
    {
        var mySprite = GetComponent<SpriteRenderer>();
        yield return mySprite.DOFade(0, _destroyTime).SetLink(gameObject).WaitForCompletion();

        Destroy(gameObject);
    }
}
