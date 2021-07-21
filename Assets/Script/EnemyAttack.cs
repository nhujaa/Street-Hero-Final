using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAttack : MonoBehaviour
{
    public float attackRange;
    public float attackStartDelay;

    public GameObject spriteobject;

    public GameObject AttackBox1, AttackBox2;
    public Sprite AttackHitframe1, AttackHitframe2;
    public Sprite currentSprite;

    NavMeshAgent navmeshagent;
    EnemySight enemysight;
    EnemyWalk enemywalk;
    EnemyState enemystate;


    Animator animator;

    void Awake()
    {
        navmeshagent = GetComponent<NavMeshAgent>();
        enemysight = GetComponent<EnemySight>();
        enemywalk = GetComponent<EnemyWalk>();
        enemystate = GetComponent<EnemyState>();
        animator = spriteobject.GetComponent<Animator>();
    }   
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        currentSprite = spriteobject.GetComponent<SpriteRenderer> ().sprite;

        if (enemystate.currentState == EnemyState.currentStateEnum.attack)
        
            Attack();
        
       
    }

    void Attack()
    {
        navmeshagent.ResetPath();
        
        if(AttackHitframe1 == currentSprite)
        {
            AttackBox1.gameObject.SetActive(true);
        }
        else if(AttackHitframe2 == currentSprite)
        {
            AttackBox2.gameObject.SetActive(false);
        }
        else
        {
            AttackBox1.gameObject.SetActive(false);
            AttackBox2.gameObject.SetActive(false);
        }



    }
    
}
