using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Coment : MonoBehaviour
{
    private Text coment;

    [SerializeField] int BaseScore0;
    [SerializeField] int BaseScore1;
    [SerializeField] int BaseScore2;
    [SerializeField] int BaseScore3;
    [SerializeField] int BaseScore4;
    [SerializeField] int BaseScore5;
    [SerializeField] int BaseScore6;
    [SerializeField] int BaseScore7;
    [SerializeField] int BaseScore8;
    [SerializeField] int BaseScore9;
    [SerializeField] int BaseScore10;
    [SerializeField] int BaseScore11;
    [SerializeField] int BaseScore12;
    [SerializeField] int BaseScore13;

    // Start is called before the first frame update
    void Start()
    {
        coment = GetComponent<Text>();

    }

    // Update is called once per frame
    void Update()
    {
        //スコア-3000の時
        if (ScoreManager.Instance.Score <= BaseScore0)
        {
            coment.text = ("ねぇ、わざとやってる？");
        }
        if (ScoreManager.Instance.Score <= BaseScore1)
        {
            coment.text = ("なつ　きらい");
        }
        //スコア-1500の時
        else if(ScoreManager.Instance.Score <= BaseScore2)
        {
            coment.text = ("なんでサメいるのよ");
        }
        //スコア-1の時
        else if (ScoreManager.Instance.Score <= BaseScore3)
        {
            coment.text = ("くやしいわ");
        }
        //スコア0の時
        else if (ScoreManager.Instance.Score <= BaseScore4)
        {
            coment.text = ("ぜろ？　なにしてたの？");
        }
        //スコア1の時
        else if (ScoreManager.Instance.Score <= BaseScore5)
        {
            coment.text = ("まぁまぁね！");
        }
        //スコア1500の時
        else if (ScoreManager.Instance.Score <= BaseScore6)
        {
            coment.text = ("やるわね！");
        }
        //スコア4000の時
        else if (ScoreManager.Instance.Score <= BaseScore7)
        {
            coment.text = ("すごいわ！");
        }
        //スコア7500の時
        else if (ScoreManager.Instance.Score <= BaseScore8)
        {
            coment.text = ("スイカわりたのしかった！");
        }
        //スコア10000の時
        else if (ScoreManager.Instance.Score <= BaseScore9)
        {
            coment.text = ("うそ、こんなにいくの？");
        }
        //スコア12500の時
        else if (ScoreManager.Instance.Score <= BaseScore10)
        {
            coment.text = ("もうさいこうね！");
        }
        //スコア15000の時
        else if (ScoreManager.Instance.Score <= BaseScore11)
        {
            coment.text = ("か、かみですか？");
        }
        //スコア17500の時
        else if (ScoreManager.Instance.Score <= BaseScore12)
        {
            coment.text = ("いいなつやすみだったわ");
        }
        //スコア40000の時
        else if (ScoreManager.Instance.Score <= BaseScore13)
        {
            coment.text = ("さいこうのなつやすみだね！");
        }
        else if (ScoreManager.Instance.Score >= 50000)
        {
            coment.text = ("ぎゃ、ぎゃくにひくわ");
        }



    }
}
