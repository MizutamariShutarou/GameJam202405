using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoisonDrink : EnemyStatus
{
    [SerializeField] private float _changeTime = -10f;
    
    public override void PlayerHitEvent(Animator playerAnim) 
    {
        TimerManager.Instance.ChangeTime(_changeTime);
        Destroy(gameObject);
    }

    public override void RodHitEvent() 
    {
        Debug.Log("毒ジュースわれました");
        Destroy(gameObject);
    }
}
