using UnityEngine;

public abstract class EnemyStatus : MonoBehaviour, ItemInterface
{
    Rigidbody2D _rb;
    [SerializeField] float _horizontalSpeed = 10;
    [SerializeField] float _verticalSpeed = 0;
    public bool _cut;
    [SerializeField] Animator _animObject;
    [SerializeField] bool _debug = true;


    // Start is called before the first frame update
    void Start()
    {
        if(_debug) ObjectMove(_horizontalSpeed, _verticalSpeed);
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
        if (_rb) _rb.AddForce(Vector2.left * horizontal + Vector2.up * vertical, ForceMode2D.Impulse);
    }

    /// <summary>プレイヤーに当たった時の処理</summary>
    public abstract void PlayerHitEvent();

    /// <summary>棒に当たった時の処理</summary>
    public abstract void RodHitEvent();
}
