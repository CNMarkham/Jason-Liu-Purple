using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectFalsePlatforms : MonoBehaviour
{
    private int PlatformLayer = LayerMask.GetMask("FalsePlatforms");
    public bool raycast;

    void Update()
    {
        raycast = Physics.Raycast(transform.forward, Vector3.forward, .15f, 1 << 8);
    }

    void FixedUpdate()
    {
        int layerMask = 1 << 8;

        RaycastHit hit;

        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity, layerMask))
        {
            Debug.Log("Did not Hit");
        }
        else
        {
            Debug.Log("Did not hit");
        }
    }
}
