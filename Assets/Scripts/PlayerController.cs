using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{   // line 6: Is referencing character controller into the code known as controller
    private CharacterController controller;
    //line 8: Direction of the player is vector 3
    private Vector3 direction;
    // line 10: This creates a new variable which is a float to control the speed which is why its public
    public float forwardSpeed;
    // line 12: 0 is the left lane, 1 is the middle lane, and 2 is the right lane but the starting lane is 1 (middle)
    public float maxSpeed; // This is the maximum speed the player can reach over time
    private int desiredLane = 1;
    // line 14: Distance between 2 lanes
    public float laneDistance = 4;
    // line 16: jumpForce is the jumpforce when the plaeyer jumps, so how high the player jumps
    public float jumpForce;
    // line 18: This is the gravity variable and is set default to -20 so that the player doesnt just fly when they jump so there is gravity to pull them back down
    public float Gravity = -20;

    void Start()
    {  //line 13: It is getting the component by using getcomponent 
       controller = GetComponent<CharacterController>(); 
    }

    // Update is called once per frame
    void Update()
    {   
        if (forwardSpeed < maxSpeed) // This checks if the  forward speed has reached the maximum speed
            forwardSpeed += 0.1f * Time.deltaTime; // This adds 0.1 speed each second if forward speed has not reached the maximum speed
       
        direction.z = forwardSpeed;

        if (controller.isGrounded) // The character controller has a function to check if the player is on the ground 
                //so the player can jump only if the character is on the ground
        {   
            direction.y = -10;
            // Checks if W is inputted so that the player can jump if inputted
            if(Input.GetKeyDown(KeyCode.W))
            {
                jump();
            }
        }
        else
        {
            // This applies the gravity to the direction of y to the player only if they are not on the ground
            direction.y += Gravity * Time.deltaTime;
        }
        //Gathers the inputs on which lane we should be on
        if (Input.GetKeyDown(KeyCode.D))
        {   
            desiredLane++;
            if (desiredLane == 3)
                desiredLane = 2;
        }
                if (Input.GetKeyDown(KeyCode.A))
        {   
            desiredLane--;
            if (desiredLane == -1)
                desiredLane = 0;
        }// the lines above have been done so that the player doesnt leave outside the lanes as the lanes are from 0-2 
        //so they can be incremented to 3 or decrement to -1 so if they are they get changed back to the correct lanes

        Vector3 targetPosition = transform.position.z * transform.forward + transform.position.y * transform.up;

        if (desiredLane == 0)
        {
            targetPosition += Vector3.left * laneDistance;
        }else if (desiredLane == 2)
            {
                targetPosition += Vector3.right * laneDistance;
            }
            
            //line 24: Now the player can move along the controller's direction
            controller.Move(direction * Time.deltaTime);

            // In the brackets the first parameter is meant to represent the starting position and 
            //the second is the target position and the rest of the code is what makes it smooth as it uses time.deltaTime
            transform.position = Vector3.Lerp(transform.position, targetPosition, 10 * Time.fixedDeltaTime);
    }
    private void jump()
    {
        direction.y = jumpForce;
    }
                // This is a predefined method that i used as i used the character controller component
    private void OnControllerColliderHit(ControllerColliderHit hit) // This checks if the player collides with an Object by using the hit parameter 
    {                                                               // which contains all the information on what the player hits
        if (hit.transform.tag == "Obstacle") // So this code checks if the player has hit any objects that have the tag Obstacle
        {
            PlayerManager.GameOver = true; // So if the player has hit any objects with the tag Obstacle then the global variable in PlayerManager is change/set to True
        }
    }

}

