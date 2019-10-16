using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chackpoint : MonoBehaviour
{
  private void OnTriggerEnter(Collider other) {
      FindObjectOfType<GameManager>().AddScore(2);
  }
}
