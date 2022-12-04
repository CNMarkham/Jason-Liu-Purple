using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [Header("Target Object")]
    public Transform target;
    // Start is called before the first frame update


    // Update is called once per frame
    void Update()
    {
        //If the position on the y axis is freater
        //than the camera position
        if(target.position.y > transform.position.y)
        {
            //The camera will follow the targets position
            transform.position =
                new Vector3(target.transform.position.x,
                            target.transform.position.y,
                            transform.position.z);
        }
    }
}
