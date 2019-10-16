using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class goal : MonoBehaviour
{
    // Start is called before the first frame update
  private void OnCollisionEnter(Collision collision) {
      FindObjectOfType<GameManager>().NextLevel();
     // GameManager.singleton.NextLevel();
  }
}
