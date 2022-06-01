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
    public GameObject playerModel;
    public GameObject playerRagdoll;

    Animator m_Animator;



    // Start is called before the first frame update
    void Start()
    {
        //Get the Animator attached to the GameObject you are intending to animate.
        m_Animator = gameObject.GetComponent<Animator>();
        //timeText = GetComponent<Text>();
        playerRagdoll.SetActive(false);
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
        //playerModel.SetActive(false);
        playerRagdoll.transform.position = playerModel.transform.position;
        playerRagdoll.transform.position += new Vector3(0, 4f, 4f);
        playerRagdoll.SetActive(true);
    }

}
