using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoisonDrink : EnemyStatus
{
    [SerializeField] private float _changeTime = -10f;
    
    public override void PlayerHitEvent(Animator playerAnim) 
    {
        TimerManager.Instance.ChangeTime(_changeTime);
        playerAnim.SetTrigger("DamageTrigger");
        SEController.Instance.RunSE(SEController.SE.Conflict);
        Destroy(gameObject);
    }

    public override void RodHitEvent() 
    {
        Debug.Log("毒ジュースわれました");
        SEController.Instance.RunSE(SEController.SE.Juice);
        Destroy(gameObject);
    }
}
