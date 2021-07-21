using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalMenu : MonoBehaviour
{
  public GameManagerrr gameManager;
  void OnTriggerEnter ()
  {
      gameManager.completeLevel();
      Time.timeScale = 0f;
  }
}
