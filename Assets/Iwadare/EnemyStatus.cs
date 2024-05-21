using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public abstract class EnemyStatus : MonoBehaviour, ItemInterface
{
    Rigidbody2D _rb;
    [SerializeField] float _horizontalValue = 1f;
    [SerializeField] float _verticalValue = 1f;
    public bool _cut;
    [SerializeField] Animator _animObject;
    public bool _isGravityScale = true;
    [SerializeField] float _destroyTime = 5f;

    [SerializeField] bool _debug = false;
    


    // Start is called before the first frame update
    void Start()
    {
        if(_debug) ObjectMove(_horizontalValue, _verticalValue);
        Destroy(this.gameObject,_destroyTime);
    }

    // Update is called once per frame
    void Update()
    {

    }

    /// <summary>デバック用処理</summary>
    public void Cut()
    {
        _cut = true;
        Debug.Log("切られた");
        if (_animObject) _animObject.SetTrigger("CutTrigget");
    }

    /// <summary>オブジェクトを動かすときの処理(派生クラスにオーバーライド可能)</summary>
    /// <param name="horizontal"></param>
    /// <param name="vertical"></param>
    public virtual void ObjectMove(float horizontal, float vertical)
    {
        Debug.Log(horizontal);
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

    /// <summary>プレイヤーに当たった時の処理</summary>
    public abstract void PlayerHitEvent();

    /// <summary>棒に当たった時の処理</summary>
    public abstract void RodHitEvent();
}
