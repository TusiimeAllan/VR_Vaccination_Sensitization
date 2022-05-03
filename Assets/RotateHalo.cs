using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateHalo : MonoBehaviour
{
   public GameObject root;

    // Update is called once per frame
    void Update()
    {
        doMath();
    }

    void doMath()
    {
        transform.position = root.transform.position;
        transform.rotation = root.transform.rotation;
    }
}
