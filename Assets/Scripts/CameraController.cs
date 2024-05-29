using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;// This new variable is the transform of the player and its called target
    private Vector3 offset;// This is the variable for the offset between the player and the camera

    void Start()
    {   // This gives the default offset between the player and the camera
        offset = transform.position - target.position;
    }

    
    void LateUpdate()// LateUpdate makes the game run more smoother than update as it updates to reflect the results after the player has moved
    {   // This calculate the new position for the camera to move so that it follows the player
        Vector3 newPosition = new Vector3 (offset.x + target.position.x, transform.position.y, offset.z + target.position.z);
        transform.position = Vector3.Lerp (transform.position, newPosition, 1f);
        // This assigns the newposition variable to the transform position of the camera so that it knows where to move
    }
}
