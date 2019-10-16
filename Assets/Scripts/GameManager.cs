using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // public static GameManager singleton;
    public int bestScore;
    public int score;

    public int currentStage = 0;
    void Awale()
    {
        // if(singleton == null){
        //     singleton =this;
        // }
        // else if(singleton != this)
        // {
        //     Destroy(gameObject);
        // }
        bestScore = PlayerPrefs.GetInt("HighScore");
    }

    public void NextLevel(){
        currentStage++;
        FindObjectOfType<PlayerContoller>().ResetBall();
        FindObjectOfType<TileManager>().LoadStage(currentStage);

    }
    public void ReStartLevel(){
        Debug.Log("ReStart Level");
            score=0;
        FindObjectOfType<PlayerContoller>().ResetBall();
        FindObjectOfType<TileManager>().LoadStage(currentStage);
        
    }

    public void AddScore(int ScoretoAdd)
    {
        score += ScoretoAdd;
        if(score > bestScore)
        {
            PlayerPrefs.SetInt("HighScore",score);
                bestScore = score;
        }

    }

}
