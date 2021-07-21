using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyState : MonoBehaviour
{
    Animator animator;
    AnimatorStateInfo currentStateinfo;
    NavMeshAgent navmeshagent;
    EnemySight enemysight;
    EnemyAttack enemyattack;
    Stats stats;

    public bool knockedDown;
    public bool tookDamage;

    public float stunTime;
    public float knockedDownTime;
    public enum currentStateEnum {idle = 0, walk = 1, attack = 2};

    public currentStateEnum currentState;

    public GameObject spriteobject;

    GameObject healthUI;

    static int currentAnimState;
    static int idleState = Animator.StringToHash("Base Layer.Stand - Bat");
    static int walkState = Animator.StringToHash("Base Layer.Run - Bat");
    static int jumpState = Animator.StringToHash("Base Layer.Jump");
    static int attack1State = Animator.StringToHash("Base Layer.Attack - Bat");
    static int attack2State = Animator.StringToHash("Base Layer.Attack - Bat2");
    

    void Awake()
    {
        navmeshagent = GetComponent<NavMeshAgent>();
        enemysight = GetComponent<EnemySight>();
        enemyattack = GetComponent<EnemyAttack>();
        animator = spriteobject.GetComponent<Animator>();
        stats = GetComponent<Stats>();
    }   

    // Update is called once per frame
    void Update()
    {
        if (knockedDown == true && tookDamage == false)
        {
            stats.displayUI = true;
            healthUI = GameObject.FindGameObjectWithTag("EnemyHealthUI");
            animator.SetBool("KnockedDown", true);
            StartCoroutine(KnockedDown());
        }
        else if (tookDamage == true)
        {
            stats.displayUI = true;
            healthUI = GameObject.FindGameObjectWithTag("EnemyHealthUI");
            animator.SetBool("IsHit", true);
            StartCoroutine(TookDamage());
        }
        else if(tookDamage == false && enemysight.playerInSight == true && enemysight.player.GetComponent<PlayerMovementScript>().knockedDown == false && enemysight.targetDistance < enemyattack.attackRange && navmeshagent.velocity.sqrMagnitude < enemyattack.attackStartDelay)
        {
            stats.displayUI = false;
            healthUI = null;
            animator.SetBool("Attack", true);
            animator.SetBool("Walk", false);
        }
        else if (knockedDown == false && tookDamage == false && enemysight.playerInSight == true)
        {
            stats.displayUI = false;
            healthUI = null;
            animator.SetBool("Walk", true);
            animator.SetBool("Attack", false);
        }
        else if (tookDamage == false && enemysight.playerInSight == false)
        {
            stats.displayUI = false;
            healthUI = null;
            animator.SetBool("Walk", false);
            animator.SetBool("Attack", false);
        }

        if(currentAnimState == idleState)
        {
            currentState = currentStateEnum.idle;
        }   
        else if(currentAnimState == walkState)
        {
            currentState = currentStateEnum.walk;
        } 
        else if (currentAnimState == attack1State)
        {
            currentState = currentStateEnum.attack;
        }
        currentStateinfo = animator.GetCurrentAnimatorStateInfo (0);
        currentAnimState =  currentStateinfo.fullPathHash;
    }

    IEnumerator TookDamage()
    {
        animator.Play ("Hurt");
        
        yield return new WaitForSeconds (stunTime);

        animator.SetBool ("IsHit", false);
        tookDamage = false;
    }

    IEnumerator KnockedDown()
    {
        animator.Play ("Knocked");
     
        yield return new WaitForSeconds (knockedDownTime);

        //animator.Play("Idle");
        animator.SetBool("KnockedDown", false);
       
        knockedDown = false;
    }
}
