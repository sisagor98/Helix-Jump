using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UIManage : MonoBehaviour
{
    public GameManager GM;
    [SerializeField] private Text textScore;
    [SerializeField] private Text textBest;

    

    void Update()
    {
        GameManager gm = GM.GetComponent<GameManager>();
        textBest.text = "Best " + gm.bestScore;
        textScore.text = "Score: " +gm.score;

    //     ScoreMenager scorePointsScript =  scoreScript.GetComponent<ScoreMenager>();
    //   scorePointsScript.AddScore ();
     }
}
