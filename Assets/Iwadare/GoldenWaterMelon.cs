using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldenWaterMelon : EnemyStatus
{
    [SerializeField] private int _changeScore = -5;
    
    public override void PlayerHitEvent() 
    {
        ScoreManager.Instance.AddScore(_changeScore);
        return;
    }

    public override void RodHitEvent() 
    {
        Debug.Log("金メロンわりました");
        Destroy(gameObject);
    }
}
