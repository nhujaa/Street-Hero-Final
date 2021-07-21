using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public GameObject enemy;
    public GameObject damageAnimation;
    

    public int health;
    public float speed;
    public float stoppingDistance;

    private Transform target;
    public Transform restArea;
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if(health <= 0)
        {   
            
            Instantiate(damageAnimation, enemy.transform.position, enemy.transform.rotation);
            enemy.SetActive(false);
        }

    }
}
