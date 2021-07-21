using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 20f;
    public float damage = 20;

    AttackCollision enemy;

    public Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        AttackCollision enemy = GetComponent<AttackCollision>();
        rb.velocity = transform.right * speed;
    }

    void OnTriggerEnter2D (Collider2D hitInfo)
    {
        

        if(enemy != null)
        {
            enemy.attackStrength = damage;
        }
    }
}
