using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathPath : MonoBehaviour
{
    private void OnEnable() {
        GetComponent<Renderer>().material.color = Color.red;
    }
    
    public void HittedDeathpath(){
        FindObjectOfType<GameManager>().ReStartLevel();
    }
}
