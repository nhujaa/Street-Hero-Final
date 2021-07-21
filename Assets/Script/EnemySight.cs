using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySight : MonoBehaviour
{
    public bool playerInSight;
    public bool playerOnRight;
    public float targetDistance;
    public GameObject target;

    public GameObject player;
    

    GameObject frontTarget;
    GameObject backTarget;

    float frontargetdistance;
    float backtargetdistance;

    
    Vector3 playerRelativePosition;
    
    // Start is called before the first frame update
    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        frontTarget = GameObject.Find("Front Target");
        backTarget = GameObject.Find("Back Target");
    }

    // Update is called once per frame
    void Update()
    {
        
      

        playerRelativePosition = player.transform.position - gameObject.transform.position;

        if(playerRelativePosition.x < 0)
         
            playerOnRight = false;
        
        else if(playerRelativePosition.x > 0)
        
            playerOnRight = true;
        

        frontargetdistance = Vector3.Distance (frontTarget.transform.position, gameObject.transform.position);
        backtargetdistance = Vector3.Distance (backTarget.transform.position, gameObject.transform.position);

        if(frontargetdistance < backtargetdistance)
        {
            target = frontTarget;
        }
        else if(frontargetdistance > backtargetdistance)
        {
            target = backTarget;
        }

          targetDistance = Vector3.Distance(target.transform.position, gameObject.transform.position);
    }

    

    void OnTriggerStay(Collider other)
    {
        if(other.gameObject == player)
            playerInSight = true;
    }

    void OnTriggerExit(Collider other)
    {
        if(other.gameObject == player)
            playerInSight = false;
    }
}
