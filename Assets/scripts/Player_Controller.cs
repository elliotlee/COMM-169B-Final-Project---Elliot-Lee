using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player_Controller : MonoBehaviour
{

    private Rigidbody rb;       // rigidbody adds physics to the object this script is placed on
    private float movementX;
    private float movementY;
    public float speed = 0;     // speed can be adjusted in the Unity program.
                                // It will be visible to modify as it is a public variable



    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>(); // connect the Rigidbody component on the object to the variable in this script
    }

    //gets vector2 value from the movement data and stores it in a vector2 variable called "movementVector"
    private void OnMove(InputValue MovementValue)   // stores the current location of the player
    {
        Vector2 movementVector = MovementValue.Get<Vector2>();
        movementX = movementVector.x;
        movementY = movementVector.y;
    }

    private void FixedUpdate()
    {
        Vector3 movement = new Vector3(movementX, 0.0f, movementY);
        // Z value is left at 0.0 because it will be handled by the physics from the rigidbody
        rb.AddForce(movement * 2 * speed);  // a force is applied to the rigidbody in the direction our new Vector3 vector is going.
    }
}
