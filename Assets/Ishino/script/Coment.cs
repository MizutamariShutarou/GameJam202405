using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Coment : MonoBehaviour
{
    private Text coment;

    [SerializeField] int BaseScore1;
    [SerializeField] int BaseScore2;
    [SerializeField] int BaseScore3;
    [SerializeField] int BaseScore4;
    [SerializeField] int BaseScore5;
    // Start is called before the first frame update
    void Start()
    {
        coment = GetComponent<Text>();

    }

    // Update is called once per frame
    void Update()
    {
        if (ScoreManager.Instance.Score <= BaseScore1)
        {
            coment.text = ("まぁまぁね");
        }
        else if(ScoreManager.Instance.Score <= BaseScore2)
        {
            coment.text = ("すごいじゃん");
        }
        else if (ScoreManager.Instance.Score <= BaseScore3)
        {
            coment.text = ("天才だね！");
        }
        else if (ScoreManager.Instance.Score <= BaseScore4)
        {
            coment.text = ("もう神！！！");
        }
        else if (ScoreManager.Instance.Score <= BaseScore5)
        {
            coment.text = ("最高の夏休みだよ！");
        }



    }
}
