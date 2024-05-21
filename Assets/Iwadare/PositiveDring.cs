using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositiveDrink : EnemyStatus
{
    [SerializeField] private float _changeTime = 3f;
    
    public override void PlayerHitEvent() 
    {
        TimerManager.Instance.ChangeTime(_changeTime);
        return;
    }

    public override void RodHitEvent() 
    {
        Debug.Log("ジュースわれました");
        Destroy(gameObject);
    }
}