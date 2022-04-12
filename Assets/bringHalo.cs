using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bringHalo : MonoBehaviour
{
    public GameObject Halo;
    
    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision collide)
    {    
        if(collide.gameObject.tag == "Respawn")        
        {
            Halo.SetActive(true);
        }        
    }

    // var meshFilter = instance.GetComponent.<MeshFilter>();
    // var mesh = meshFilter.sharedMesh;
    // Debug.Log(mesh.name);
}
