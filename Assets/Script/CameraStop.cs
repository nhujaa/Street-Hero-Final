using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraStop : MonoBehaviour
{
   public GameObject otherObject;

   void OnTriggerEnter (Collider other)
   {
       if(other.tag == "CameraMidpoint")
       {
            otherObject = other.transform.parent.gameObject;
            CameraController.isFollowing = false;
            gameObject.SetActive (false);
       }
       else 
            return;
   }
}
