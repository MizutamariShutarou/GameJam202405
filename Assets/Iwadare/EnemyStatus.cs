using UnityEngine;

public class EnemyStatus : MonoBehaviour, ItemInterface
{
    Rigidbody2D _rb;
    [SerializeField] float _horizontalSpeed = 10;
    [SerializeField] float _verticalSpeed = 0;
    public bool _cut;
    [SerializeField] Animator _animObject;
    [SerializeField] bool _initMove = true;


    // Start is called before the first frame update
    void Start()
    {
       
        if(_initMove) ObjectMove(_horizontalSpeed, _verticalSpeed);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ObjectMove(float horizontal, float vertical)
    {
        _rb = GetComponent<Rigidbody2D>();
        if (_rb) _rb.velocity = Vector2.left * horizontal + Vector2.down * vertical;
    }

    public void Cut()
    {
        _cut = true;
        Debug.Log("切られた");
        if (_animObject) _animObject.SetTrigger("CutTrigget");
    }

    public virtual void ItemEventActivate() { return; }
}
