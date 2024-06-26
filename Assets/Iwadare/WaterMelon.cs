﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterMelon : EnemyStatus
{
    [SerializeField] int _plusScore = 3;

    public override void PlayerHitEvent(Animator playerAnim) 
    {
        playerAnim.SetTrigger("HitTrigger");
        SEController.Instance.RunSE(SEController.SE.Conflict);
        Destroy(gameObject);
    }

    public override void RodHitEvent() 
    {
        ScoreManager.Instance.AddScore(_plusScore);
        /// 割れる処理
        Debug.Log("メロン割れた");
        if (_animObject) _animObject.SetTrigger("CutTrigger");
        SEController.Instance.RunSE(SEController.SE.Attack);
        StartCoroutine(EnemyDestroyTime());
        /// 
    }
}
