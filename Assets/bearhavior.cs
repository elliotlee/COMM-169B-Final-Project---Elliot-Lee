using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class bearhavior : MonoBehaviour
{
    public float happy = 10;
    public bool alive = true;
    public Text timeText;
    public bool walkIdleTransition = false;
    public GameObject model;
    public GameObject ragdoll;
    public GameObject apple;
    public GameObject hammer;


    Animator m_Animator;



    // Start is called before the first frame update
    void Start()
    {
        //Get the Animator attached to the GameObject you are intending to animate.
        m_Animator = gameObject.GetComponent<Animator>();
        //timeText = GetComponent<Text>();
        ragdoll.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        

        //if (happy <= 0)
        //{
        //    alive = false;
        //}

        if (alive) 
        {
            //happy = m_Animator.GetFloat("happy");
            if (happy > 0)
            {
                happy -= Time.deltaTime;
                m_Animator.SetFloat("happiness", happy);
                Debug.Log("adjusting happiness!");
                //DisplayTime(happy);

                /*if (Input.GetButtonDown("Trigger")) find a different way to do this
                {
                    m_Animator.SetFloat("Happy", happy + 5);
                }*/

                
                
            }
            else
            {
                m_Animator.SetBool("alive", false);
                alive = false;
                happy = 0;

                Debug.Log("BEAR DEAD!");
                Invoke("swapRagdoll", 2);

            }

        }
        

    }


    /*void DisplayTime(float timeToDisplay)
    {
        timeToDisplay += 1;
        float seconds = Mathf.FloorToInt(happy % 60);
        timeText.text = string.Format("{1:00}", seconds);
    }*/


    void swapRagdoll()
    {
        model.SetActive(false);
        ragdoll.transform.position = model.transform.position;
        ragdoll.transform.position += new Vector3(0, 4f, 4f);
        ragdoll.SetActive(true);
    }



    void OnCollisionEnter(Collision collision)
    {
        //Check for a match with the specified name on any GameObject that collides with your GameObject
        if (collision.gameObject.name == "apple")
        {
            happy += 5;
            m_Animator.SetFloat("happiness", happy + 5);
            Debug.Log("ate apple");
        }

        if (collision.gameObject.name == "hammer_low")
        {
            happy -= 5;
            m_Animator.SetFloat("happiness", happy - 5);
            Debug.Log("hit with hammer");
        }

        //Check for a match with the specific tag on any GameObject that collides with your GameObject
        if (collision.gameObject.tag == "MyGameObjectTag")
        {
            //If the GameObject has the same tag as specified, output this message in the console
            Debug.Log("Do something else here");
        }
    }



}
