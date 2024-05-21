using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shark : EnemyStatus
{
    [SerializeField] private int _changeScore = -3;
    
    public override void PlayerHitEvent() 
    {
        ScoreManager.Instance.AddScore(_changeScore);
        return;
    }

    public override void RodHitEvent() 
    {
        Debug.Log("サメ死亡");
        Destroy(gameObject);
    }
}
