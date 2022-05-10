using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

//a public gameobject reference to the player game object
    public GameObject player;
    //stores the offset value as private
    private Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
               //current transform position of the camera GameObject and subtract the transform position of the player gameobject
        //in other words camera position minus player position
        offset = transform.position - player.transform.position;

    }

        void LateUpdate()
    {
        //use the offset to set the camera GameObjects transform position
        //And does so at every frame (hence under the Update function and not the Start)\
        //hence the camera ONLY matches the position, and not the rotation of the object
        transform.position = player.transform.position + offset;
	}

}
