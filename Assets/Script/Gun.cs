using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{   
    public GameObject pickupEffect;

    public float duration = 10f;
    
   void OnTriggerEnter(Collider other)
   {
       if(other.CompareTag("Player"))
       {
           StartCoroutine (Pickup(other));
       }
   }

   IEnumerator Pickup(Collider player)
   {
       Instantiate(pickupEffect, transform.position, transform.rotation);

       PlayerMovementScript modifier = player.GetComponent<PlayerMovementScript>();
       modifier.hasGun = true;
        
       GetComponent<MeshRenderer>().enabled = false;
       GetComponent<Collider>().enabled = false; 
       

       yield return new WaitForSeconds (duration);

       modifier.hasGun = false;

       Destroy(gameObject);
       
   }
}
