using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        // 以下はギミック効果のデバッグ
        if (Input.GetButtonDown("Jump"))
        {
            TimerManager.Instance.ChangeTime(-10f);
        }
        if (Input.GetButtonDown("Fire1"))
        {
            ScoreManager.Instance.AddScore(100);
        }
    }

    /// <summary>
    /// 初期化
    /// </summary>
    private void Initialize()
    {
        
    }
}
