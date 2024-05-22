using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ObjectDestroyTime : MonoBehaviour
{
    [SerializeField] float _destroyTime = 2.0f;
    SpriteRenderer _mySprite;
    [SerializeField] bool _isScaleChange;
    [SerializeField] float _scaleChangeTime = 0.5f;
    // Start is called before the first frame update
    void Start()
    {
        _mySprite = GetComponent<SpriteRenderer>();
        StartCoroutine(DestroyEnemy());
    }

    IEnumerator DestroyEnemy()
    {
        if (_isScaleChange) 
        {
            var tmpScale = transform.localScale;
            transform.localScale = Vector2.zero;
            transform.DOScale(tmpScale,_scaleChangeTime);
        }
        yield return _mySprite.DOFade(0,_destroyTime).SetLink(gameObject).WaitForCompletion();
        
        Destroy(gameObject);
    }
}