using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public static bool isFollowing = true;
    public float cameraSpeed;
    
    Vector3 playerXPos;
    GameObject playerTarget;
    
    void Awake()
    {
        playerTarget = GameObject.FindGameObjectWithTag ("Player");
    }

    // Update is called once per frame
    void Update()
    {
        playerXPos = new Vector3 (playerTarget.transform.position.x, 0.0f, 0.0f);
        if(isFollowing == true)
        {
            transform.position = Vector3.Lerp (transform.position, playerXPos, cameraSpeed)  ;
        }
    }
}
