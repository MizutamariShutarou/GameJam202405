using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shark : EnemyStatus
{
    [SerializeField] private int _changeScore = -3;
    [SerializeField] private GameObject _deathShark;
    public override void PlayerHitEvent(Animator playerAnim) 
    {
        ScoreManager.Instance.AddScore(_changeScore);
        return;
    }

    public override void RodHitEvent() 
    {
        Debug.Log("サメ死亡");
        var shark = Instantiate(_deathShark,transform.position,Quaternion.identity);
        shark.transform.localScale = transform.localScale;
        Destroy(gameObject);
    }
}
