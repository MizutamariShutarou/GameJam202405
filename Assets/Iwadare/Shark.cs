using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shark : EnemyStatus
{
    [SerializeField] private int _addScore = 0;
    [SerializeField] private int _decreaseScore = -3;
    [SerializeField] private GameObject _deathShark;
    public override void PlayerHitEvent(Animator playerAnim) 
    {
        ScoreManager.Instance.AddScore(_decreaseScore);
        playerAnim.SetTrigger("DamageTrigger");
        SEController.Instance.RunSE(SEController.SE.Conflict);
        return;
    }

    public override void RodHitEvent() 
    {
        Debug.Log("サメ死亡");
        ScoreManager.Instance.AddScore(_addScore);
        var shark = Instantiate(_deathShark,transform.position,Quaternion.identity);
        shark.transform.localScale = transform.localScale;
        SEController.Instance.RunSE(SEController.SE.Attack);
        Destroy(gameObject);
    }
}
