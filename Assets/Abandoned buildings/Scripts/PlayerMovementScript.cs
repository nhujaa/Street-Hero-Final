using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementScript : MonoBehaviour
{
    public float walkingMovementSpeed;
    public float attackMovementSpeed;
    public float xMin, xMax, zMin, zMax;
    public float knockeddownTime;
    public bool isBlocking;
    public bool tookDamage;
    public bool hasGun;
    public float stunTime;
    public bool knockedDown;
    public float knockBackForce;

    private float movementSpeed;
    public bool facingRight;
    public bool canMove;

    private Rigidbody rigidBody;

    Animator animator;
    AnimatorStateInfo currentStateInfo;

    public GameObject AttackBox, AttackBox2;
    public Sprite AttackHitframe, AttackHitFrame2;

    Stats stat;

    SpriteRenderer currentSprite;

    static int currentState;
    static int idleState = Animator.StringToHash("Base Layer.Idle");
    static int walkState = Animator.StringToHash("Base Layer.Walk");
    static int jumpState = Animator.StringToHash("Base Layer.Jump");
    static int slideState = Animator.StringToHash("Base Layer.Slide");
    static int gunState = Animator.StringToHash("Base Layer.Gun");

    // Start is called before the first frame update
    void Start()
    {
        currentSprite = GetComponent<SpriteRenderer>();
        rigidBody = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        stat = GetComponent<Stats>();
        movementSpeed = walkingMovementSpeed;
        facingRight = true; 
        canMove = true;
    }

    // Update is called once per frame
    void Update()
    {
        currentStateInfo = animator.GetCurrentAnimatorStateInfo(0);
        currentState = currentStateInfo.fullPathHash;
        
/*
        if (currentState == idleState)
        {
            Debug.Log("Idle");
        }
        if (currentState == walkState)
        {
            Debug.Log("Walk");
        }*/

        if(currentState == idleState || currentState == walkState)
        {
            movementSpeed = walkingMovementSpeed;
        }
        else
        {
            movementSpeed = attackMovementSpeed;
        }

        
    }

    void FixedUpdate()
    {

        //Movement
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        rigidBody.velocity = movement * movementSpeed;
        rigidBody.position = new Vector3
                                        (Mathf.Clamp(rigidBody.position.x, xMin, xMax),
                                        transform.position.y, Mathf.Clamp(rigidBody.position.z, zMin, zMax));

        if (moveHorizontal > 0 && !facingRight && canMove == true)
        {
            Flip();
        }
        else if(moveHorizontal < 0 && facingRight && canMove == true)
        {
            Flip();
        }

        animator.SetFloat ("Speed", rigidBody.velocity.sqrMagnitude);

        //Attack
        if (Input.GetMouseButton(0))
        {
            animator.SetBool("Attack", true);
        }
        //else if (Input.GetMouseButton(1))
       // {
        //    animator.SetBool("Attack", true);
       // }
        else
        {
            animator.SetBool("Attack", false);
        }

        if(AttackHitframe == currentSprite.sprite)
        {
            AttackBox.gameObject.SetActive(true);
        }
        //else if(AttackHitFrame2 == currentSprite.sprite)
       // {
        //    AttackBox2.gameObject.SetActive(true);
       // }
        else 
        {
            AttackBox.gameObject.SetActive(false);
        }
        
       if(Input.GetKeyDown(KeyCode.G) && gameObject.tag == "Player")
       {
           stat.health += 1000;
       }

        if(Input.GetKeyDown(KeyCode.H) && gameObject.tag == "Player")
       {
           stat.health = 50;
       }

        //Hurt
        if (tookDamage == true && knockedDown == false)
        {
            StartCoroutine (TookDamage());
        }

        if(knockedDown == true)
        {
            StartCoroutine(KnockedDown());
        }

        //GunAttack
        //if(Input.GetKeyDown(KeyCode.Space) && hasGun == true)
       // {
       //     GunShot();
       // }

        

        

    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 thisScale = transform.localScale;
        thisScale.x *= -1;
        transform.localScale = thisScale;
    }

    IEnumerator TookDamage()
    {
        animator.Play ("Hurt");
        canMove = false;

        yield return new WaitForSeconds (stunTime);

        canMove = true;
        tookDamage = false;
    }

    IEnumerator KnockedDown()
    {
        animator.Play ("Death");
        animator.SetBool ("KnockedDown", true);
        canMove = false;
/*
        if(facingRight == false)
        {
            rigidBody.AddForce (transform.right * knockBackForce);
        }
        else if(facingRight == true)
        {
            rigidBody.AddForce (transform.right *(-1 * knockBackForce));
        }
*/
        yield return new WaitForSeconds (knockeddownTime);

        animator.Play("Idle");
        animator.SetBool("KnockedDown", true);
        canMove = true;
        knockedDown = false;
    }

    

   
    
}
