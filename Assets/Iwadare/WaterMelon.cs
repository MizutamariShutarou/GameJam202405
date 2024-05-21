using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterMelon : EnemyStatus
{
    [SerializeField] int _plusScore = 3;

    public override void PlayerHitEvent() 
    {
        return;
    }

    public override void RodHitEvent() 
    {
        ScoreManager.Instance.AddScore(_plusScore);
        /// 割れる処理
        if (_animObject) _animObject.SetTrigger("CutTrigget");
        /// 
    }
}
