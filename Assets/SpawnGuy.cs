using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnGuy : MonoBehaviour
{
    public GameObject WhatToInstantiate; //Set this in the inspector to what you want to spawn
    [SerializeField] private int NumberOfGuys;
    
    // Update is called once per frame
    void Update()
    {
        for(int i=0; i < NumberOfGuys; i++)
        {
            Debug.Log("Number: " + i);
            // Instantiate(WhatToInstantiate, transform.position, transform.rotation);
        }
    }
}
