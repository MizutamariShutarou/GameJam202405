using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bom : EnemyStatus
{
    [SerializeField] int _addScore = -1;
    public override void PlayerHitEvent()
    {
        ScoreManager.Instance.AddScore(_addScore);
        /// 爆発処理
        Debug.Log("ボム爆発");
        /// 
    }

    public override void RodHitEvent()
    {
        ScoreManager.Instance.AddScore(_addScore);
        /// 爆発処理
        Debug.Log("ボム爆発");
        /// 
    }
}
