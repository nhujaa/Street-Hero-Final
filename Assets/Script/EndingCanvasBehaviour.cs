using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndingCanvasBehaviour : MonoBehaviour
{
   public GameObject uI;

   void Update()
   {

   }


   public void loadMenu()
   {
       SceneManager.LoadScene("Scenes/Menu");
   }
   public void tryAgain()
   {
       SceneManager.LoadScene("Scenes/MainScene");
   }

   public void quitGame()
   {
       Application.Quit();
   }
}
