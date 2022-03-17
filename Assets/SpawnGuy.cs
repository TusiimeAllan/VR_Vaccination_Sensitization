using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnGuy : MonoBehaviour
{
    public GameObject WhatToInstantiate; //Set this in the inspector to what you want to spawn
    [SerializeField] private int NumberOfGuys;
    
    // Update is called once per frame
    void Start()
    {
        StartCoroutine(Bring());
        
    }

    IEnumerator Bring()  //  <-  its a standalone method
    {
        for(int i=0; i < NumberOfGuys; i++)
        {
            Debug.Log("Number: " + i);
            // yield return new WaitForSeconds(4f);
            Instantiate(WhatToInstantiate, transform.position, transform.rotation);
            yield return new WaitForSeconds(2f);
            
                        
        }
        
    }
}
