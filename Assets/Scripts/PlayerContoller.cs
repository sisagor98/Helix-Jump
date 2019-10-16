using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerContoller : MonoBehaviour
{
    public Rigidbody rb;
    public float impulseForce = 5f;
    private bool ignoreNextCollision;
    public GameObject GM;

    private Vector3 startPos;
    void Start()
    {
        startPos = transform.position;
        //GetComponent<GameManager>();
    }

    private void OnCollisionEnter(Collision collision) {

        if(ignoreNextCollision)
            return;

        DeathPath deathpath = collision.transform.GetComponent<DeathPath>();
        if(deathpath)
            deathpath.HittedDeathpath();

    
        rb.velocity = Vector3.zero; // Remove velocity to not make the ball jump higher after falling done a greater distance
        rb.AddForce(Vector3.up * impulseForce, ForceMode.Impulse);
        
        ignoreNextCollision = true;
        Invoke("AllowCollision", .2f);

        //gameManager.GetComponent<GameManager>().AddScore(1);
        //  GameManager.singleton.AddScore(1);
        //  Debug.Log(GameManager.singleton.score);

            // GameManager gm = GM.GetComponent<GameManager>();
            // gm.AddScore(1);
        // ScoreMenager scorePointsScript =  scoreScript.GetComponent<ScoreMenager>();
        // scorePointsScript.AddScore ();

    }


    private void AllowCollision(){
        ignoreNextCollision = false;
    }

    // Update is called once per frame
   public void ResetBall(){
       transform.position = startPos;
   }
}
