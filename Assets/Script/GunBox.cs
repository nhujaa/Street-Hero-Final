using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunBox : MonoBehaviour
{   
    public GameObject pickupEffect;

    
    public float multiplier = 1.4f;
    
   void OnTriggerEnter(Collider other)
   {
       if(other.CompareTag("Player"))
       {
           Pickup(other);
       }
   }

   void Pickup(Collider player)
   {
       Instantiate (pickupEffect, transform.position, transform.rotation);
       FindObjectOfType<SoundManager>().Play("Health");
       Stats stats = player.GetComponent<Stats>();
       stats.health *= multiplier;
       
       Debug.Log ("HealthPicked");

       Destroy(gameObject);
   }
}
