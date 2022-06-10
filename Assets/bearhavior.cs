using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class bearhavior : MonoBehaviour
{
    public float happy = 10;            // base happiness level
    public bool alive = true;

    public GameObject model;            // bear model
    public GameObject ragdoll;          // ragdoll model
    public GameObject apple;            // apple model
    public GameObject hammer;           // hammer model
    public GameObject player;           // XR rig 

    public float TargetDistance;        // distance we want the object to be from the player.
    public float AllowedDistance = 7;   // max distance before beginning to walk toward the player.
    public float FollowSpeed;           // how quickly the object can follow the player.

    public RaycastHit RayOut;           // vector sent out from the model to the player to determine the distance between.
    Animator m_Animator;                // animator is connected to this variable.

    // Start is called before the first frame update
    void Start()
    {
        //Get the Animator attached to the GameObject you are intending to animate.
        m_Animator = gameObject.GetComponent<Animator>();
        ragdoll.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
        if (alive)
        {
            // code to follow the player and control walking/idle animation.
            transform.LookAt(player.transform);     // object will look at the player.
            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out RayOut)) // defines the state we want to fire a raycast out from.
                                                                                                                // (gets position of object, transforms object to face toward player, ray is shot out from object)
            {
                TargetDistance = RayOut.distance;
                if (TargetDistance >= AllowedDistance)   // check if the distance from the obj to player is > than our specified distance.
                {
                    FollowSpeed = 0.1f;
                    m_Animator.SetBool("walking", true);    // changes the state of the bool "walking" in the animation component attached to the model in Unity
                    transform.position = Vector3.MoveTowards(transform.position, player.transform.position, FollowSpeed);   // moves obj toward the diretion it is looking (toward player)
                }
                else   // else don't walk and set the "walking" bool in the animation component to false to play the idle animation.
                {
                    FollowSpeed = 0;
                    m_Animator.SetBool("walking", false);
                }
            }


            // code to adjust the variables in the animation component.
            if (happy > 0)
            {
                happy -= Time.deltaTime;        // happy goes down 1 per second
                m_Animator.SetFloat("happiness", happy);    // play happy animation while not walking
            }
            else
            {
                m_Animator.SetBool("alive", false);         // play death animation.
                alive = false;
                happy = 0;
                Debug.Log("BEAR DEAD!");
                Invoke("swapRagdoll", 3);                   // the invoke function can have a second variable to schedule a function call after a time delay (seconds). It is 3 to allow the death animation to play.
            }
        }
    }




    void swapRagdoll()
    {
        model.SetActive(false); // make the current model invisible
        ragdoll.transform.position = model.transform.position;  // move the ragdoll object to the same place as the current object
        ragdoll.transform.position += new Vector3(0, 4f, 4f);   // moved the ragdoll up a bit and back so that it would stop clipping through the floor
        ragdoll.SetActive(true);                                // make the ragdoll object visible
    }


    void OnCollisionEnter(Collision collision)
    {
        //Check for a match with the specified name on any GameObject that collides with your GameObject
        if (collision.gameObject.name == "apple")       // if you feed the object, happiness goes up
        {
            happy += 5;
            m_Animator.SetFloat("happiness", happy + 5);    // adjust the variable in the animation component
            Debug.Log("ate apple");
        }

        if (collision.gameObject.name == "hammer_low")  // if you hit the object with your hammer, happiness goes down
        {
            happy -= 5;
            m_Animator.SetFloat("happiness", happy - 5);    // adjust the variable in the animation component
            Debug.Log("hit with hammer");
        }
    }


}



//timeText = GetComponent<Text>();

//public Text timeText;

/*void DisplayTime(float timeToDisplay)
{
    timeToDisplay += 1;
    float seconds = Mathf.FloorToInt(happy % 60);
    timeText.text = string.Format("{1:00}", seconds);
}*/

//DisplayTime(happy);