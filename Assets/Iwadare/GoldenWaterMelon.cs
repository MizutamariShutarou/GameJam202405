using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldenWaterMelon : EnemyStatus
{
    [SerializeField] private int _changeScore = -5;
    
    public override void PlayerHitEvent() 
    {
        Destroy(gameObject);
        return;
    }

    public override void RodHitEvent() 
    {
        ScoreManager.Instance.AddScore(_changeScore);
        Debug.Log("金メロンわりました");
        _animObject.SetTrigger("CutTrigger");
        StartCoroutine(EnemyDestroyTime());
    }
}
