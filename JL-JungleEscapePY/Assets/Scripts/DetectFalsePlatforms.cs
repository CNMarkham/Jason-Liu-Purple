using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectFalsePlatforms : MonoBehaviour
{
    private int PlatformLayer;
    public bool raycast;

    void Start()
    {
        PlatformLayer = LayerMask.GetMask("FalsePlatforms");
    }

    void FixedUpdate()
    {
        int layerMask = 1 << 8;

        layerMask = ~layerMask;

        Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward), Color.cyan);
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), 3f, 1<<8))
        {
            Debug.Log("Watch out");
        }
        else
        {
            Debug.Log("All clear");
        }
    }
}
