using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositiveDrink : EnemyStatus
{
    [SerializeField] private float _changeTime = 3f;
    
    public override void PlayerHitEvent(Animator playerAnim) 
    {
        TimerManager.Instance.ChangeTime(_changeTime);
        Destroy(gameObject);
    }

    public override void RodHitEvent() 
    {
        Debug.Log("ジュースわれました");
        Destroy(gameObject);
    }
}