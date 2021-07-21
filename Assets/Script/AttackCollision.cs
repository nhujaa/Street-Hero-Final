using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AttackCollision : MonoBehaviour
{
    public bool knockDownAttack;
    public float attackStrength;
    public float score = 0;
    public Text scoreText;
    public Text scoreText2;

    GameObject otherObject;

    public GameObject playertookdamage;

    PlayerMovementScript playerState;
    EnemyState enemystate;
    Bullet bulletstate;

    Stats otherStats;

    void Start()
    {
        scoreText.text = "Score: " + score.ToString();
        scoreText2.text = "Score: " + score.ToString();
    }
    void OnTriggerEnter(Collider other)
    {
        if(gameObject.tag == "PlayerAttackBox" && other.tag == "EnemyHitbox")
        {
            FindObjectOfType<SoundManager>().Play("EnemyHit");
            //enemy takes damage
            EnemyTakeDamage(other.gameObject);
        }
        
        else if (gameObject.tag == "EnemyAttackBox" && other.tag == "PlayerHitbox")
        {
            FindObjectOfType<SoundManager>().Play("PlayerHit");
            //player takes damage
            PlayerTakeDamage(other.gameObject);
            Instantiate (playertookdamage, transform.position, transform.rotation);
            Destroy(playertookdamage.gameObject);
        }
        else 
            return;

    }

    void EnemyTakeDamage(GameObject other)
    {
        otherObject = other.transform.parent.gameObject;
        enemystate = otherObject.GetComponent<EnemyState>();
        otherStats = otherObject.GetComponent<Stats>();

        otherStats.health = otherStats.health - attackStrength;
        score += 1;
        scoreText.text = "Score: " + score.ToString();
        scoreText2.text = "Score: " + score.ToString();
        Debug.Log("Enemy Hit");

         if(knockDownAttack == true)
        {
            enemystate.knockedDown = true;
        }
        else{
            enemystate.tookDamage = true;
        }
    }

    void PlayerTakeDamage(GameObject other)
    {
        otherObject = other.transform.parent.gameObject;
        playerState = otherObject.GetComponent<PlayerMovementScript>();
        otherStats = otherObject.GetComponent<Stats>();

        otherStats.health = otherStats.health - attackStrength;
        otherStats.healthRemaining.text = (otherStats.health - attackStrength).ToString();
        otherStats.healthRemaining2.text = (otherStats.health - attackStrength).ToString();
        if(knockDownAttack == true)
        {
            playerState.knockedDown = true;
        }
        else{
            playerState.tookDamage = true;
        }
        Debug.Log("Player Hit");
    }

}
