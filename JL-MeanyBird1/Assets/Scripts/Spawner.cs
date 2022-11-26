using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    //Object that will attacj to the script for the spawning object
    [Header("Spikes Object for the controlling the game")]
    public GameObject spikes;
    //Height position of hte spikes 
    [Header("Default Height")]
    public float height;
    // Start is called before the first frame update
    void Start()
    {
        //Start funciton repeatign every 4 seconds
        InvokeRepeating("InstantiateObjects", 1f, 4f);
    }

    // Update is called once per frame
    void Update()
    {
        //Position for the gameObjects
        transform.position = new Vector3(5, Random.Range(-height, height), 0);
    }

//InstantiateObjects Function
    void InstantiateObjects()
    {
        //Spawn object by position and rotation 
        Instantiate(spikes, transform.position, transform.rotation);
    }
}
