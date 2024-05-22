using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldenWaterMelon : EnemyStatus
{
    [SerializeField] private int _changeScore = -5;
    
    public override void PlayerHitEvent(Animator playerAnim) 
    {
        playerAnim.SetTrigger("HitTrigger");
        SEController.Instance.RunSE(SEController.SE.Conflict);
        Destroy(gameObject);
        return;
    }

    public override void RodHitEvent() 
    {
        ScoreManager.Instance.AddScore(_changeScore);
        Debug.Log("金メロンわりました");
        _animObject.SetTrigger("CutTrigger");
        SEController.Instance.RunSE(SEController.SE.Attack);
        StartCoroutine(EnemyDestroyTime());
    }
}
