using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bom : EnemyStatus
{
    [SerializeField] int _addScore = -1;
    [SerializeField] GameObject _explosion;
    [SerializeField] GameObject _smork;
    public override void PlayerHitEvent(Animator playerAnim)
    {
        ScoreManager.Instance.AddScore(_addScore);
        /// 爆発処理
        Instantiate(_explosion, transform.position, Quaternion.identity);
        Instantiate(_smork, transform.position, Quaternion.identity);
        SEController.Instance.RunSE(SEController.SE.Bomb);
        playerAnim.SetTrigger("DamageTrigger");
        Debug.Log("ボム爆発");
        /// 
        Destroy(gameObject);
    }

    public override void RodHitEvent()
    {
        ScoreManager.Instance.AddScore(_addScore);
        /// 爆発処理
        Instantiate(_explosion,transform.position,Quaternion.identity);
        Instantiate(_smork, transform.position, Quaternion.identity);

        SEController.Instance.RunSE(SEController.SE.Bomb);
        Animator playerAnim = GameObject.FindWithTag("Player").GetComponent<Animator>();
        playerAnim.SetTrigger("DamageTrigger");
        Debug.Log("ボム爆発");
        /// 
        Destroy(gameObject);
    }
}
