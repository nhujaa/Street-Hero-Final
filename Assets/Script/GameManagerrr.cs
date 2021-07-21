using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManagerrr : MonoBehaviour
{
    public GameObject [] enemyArray;

    public static GameManagerrr instance = null;

    public GameObject completeLevelUI;

    public float resetTime = 2.0f;
    public float timeSlowDown = 0.05f;
    // Start is called before the first frame update
    void Start()
    {
        
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        enemyArray = GameObject.FindGameObjectsWithTag ("Enemy");

        if(enemyArray.Length == 0)
        {
            CameraController.isFollowing = true;
        }
    }

    public void GameOver()
    {
        Invoke ("Reset", resetTime);

    }

    void Reset()
    {
        Time.timeScale = 1.0f;
        Application.LoadLevel (Application.loadedLevel); 
    }

    public void completeLevel()
    {
        completeLevelUI.SetActive(true);
        Time.timeScale = 0f;
    }
}
