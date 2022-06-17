using System.Collections;
using UnityEngine;

public class Floater : MonoBehaviour
{
    public float floatStrength;
    public float randomRotationStrength;
    public float floatingPosition;
     
    void Update () {
        transform.GetComponent<Rigidbody>().AddForce(Vector3.up *floatStrength);
        transform.Rotate(randomRotationStrength,randomRotationStrength,randomRotationStrength);
    }

    void FixedUpdate()
         {
     
             if (transform.position.y < floatingPosition)
             {
                 Debug.Log("force being applied upwards to move object up");
                 transform.GetComponent<Rigidbody>().AddForce(Vector3.up * floatStrength);
                 transform.Rotate(randomRotationStrength, randomRotationStrength, randomRotationStrength);
             }
             if (transform.position.y >= floatingPosition)
             {
                 Debug.Log("force applied is less than the gravitational force so that the object comes down. Here mass of object is 2.  ");
                 transform.GetComponent<Rigidbody>().AddForce(Vector3.up * 11.0f);
                 transform.Rotate(randomRotationStrength, randomRotationStrength, randomRotationStrength);
             }
         }
}
