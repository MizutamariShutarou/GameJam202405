using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositiveDrink : EnemyStatus
{
    [SerializeField] private float _changeTime = 3f;
    
    public override void PlayerHitEvent(Animator playerAnim) 
    {
        TimerManager.Instance.ChangeTime(_changeTime);
        ///ドリンクのむSE追加
        SEController.Instance.RunSE(SEController.SE.Drink);
        Destroy(gameObject);
    }

    public override void RodHitEvent() 
    {
        Debug.Log("ジュースわれました");
        SEController.Instance.RunSE(SEController.SE.Juice);
        Destroy(gameObject);
    }
}