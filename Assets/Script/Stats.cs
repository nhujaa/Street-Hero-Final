using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stats : MonoBehaviour
{
    public float startinghealth;
    public float health;
    
    public bool displayUI;

    public Text healthRemaining;
    public Text healthRemaining2;

    public bool godMode = false;

    public Slider healthSlider;

    public GameObject healthUI;

    GameManagerrr playerDeath;
 

    public bool enemyToWin;

    void Awake()
    {
        health = startinghealth;
    }

    void Update()
    {
        if(gameObject.tag == ("Player"))
        {
            healthUI = GameObject.FindGameObjectWithTag("PlayerHealthUI");
            healthSlider = healthUI.gameObject.transform.GetChild(0).GetComponent<Slider>();
            if(healthSlider.maxValue == 0)
            {
                healthSlider.maxValue = startinghealth;
            }
            healthSlider.value = health;

            healthRemaining.text = "Health Remaining: " + health.ToString();
            healthRemaining2.text = "You had " + health.ToString() + " health remaining!";
        }

        if(gameObject.tag == ("Player"))
        {
            if(health <= 0)
            {   
                Destroy(gameObject);
                GameManagerrr.instance.completeLevel();
            }
        }

        if(gameObject.tag == ("Enemy") && displayUI == true)
        {
            healthUI = GameObject.FindGameObjectWithTag("EnemyHealthUI");
            healthSlider = healthUI.gameObject.transform.GetChild(0).GetComponent<Slider>();
            if(healthSlider.maxValue == 0)
            {
                healthSlider.maxValue = startinghealth;
            }
            healthSlider.value = health;
        }

        if(health <= 0 && gameObject.tag == ("Enemy"))

            Destroy(gameObject.transform.parent.gameObject);
            if(enemyToWin == true)
            {
                
                Time.timeScale = 0.5f;
                GameManagerrr.instance.completeLevel();
                //GameManagerrr.instance.GameOver(); 
            }

        

    }

}
