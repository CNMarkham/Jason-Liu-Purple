using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectFalsePlatforms : MonoBehaviour
{
    private int PlatformLayer = LayerMask.GetMask("FalsePlatforms");
    public bool raycast;

    void Update()
    {
        
        raycast = Physics.Raycast(transform.forward, Vector3.forward, .15f);


    }
}
