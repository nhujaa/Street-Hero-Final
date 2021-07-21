using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyWalk : MonoBehaviour
{
    public float enemySpeed;
    public float enemyCurrentSpeed;
    bool facingRight;
    public GameObject spriteObject;

    EnemyState enemystate;

    Animator animator;
    NavMeshAgent navmeshagent;
    EnemySight enemysight;


    // Start is called before the first frame update
    void Awake()
    {
        navmeshagent = GetComponent<NavMeshAgent>();
        enemysight = GetComponent<EnemySight>();
        enemystate = GetComponent<EnemyState>();
        animator = spriteObject.GetComponent<Animator>();
        navmeshagent.speed = enemySpeed;

    }

    // Update is called once per frame
    void Update()
    {
        
        if (enemystate.currentState == EnemyState.currentStateEnum.walk)
        {
            Walk();
        }
        else if(enemystate.currentState == EnemyState.currentStateEnum.idle)
        {
            Stop();
        }
       
    }

    void Walk()
    {
         if(enemysight.playerOnRight == true && facingRight)
        {
            Flip();
        }
        else if(enemysight.playerOnRight == false && !facingRight)
        {
            Flip();
        }

        navmeshagent.speed = enemySpeed;
        enemyCurrentSpeed = navmeshagent.velocity.sqrMagnitude;
        navmeshagent.SetDestination (enemysight.target.transform.position);
        navmeshagent.updateRotation = false;
    }

    void Stop()
    {
        navmeshagent.ResetPath();
    }

     void Flip()
    {
        facingRight = !facingRight;
        Vector3 thisScale = transform.localScale;
        thisScale.x *= -1;
        transform.localScale = thisScale;
    }
}
