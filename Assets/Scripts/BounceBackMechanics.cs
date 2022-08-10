using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BounceBackMechanics : MonoBehaviour
{
    [SerializeField] private string playerTag;
    [SerializeField] private float bounceForce;

    // void Start()
    // {
    //     bounceForce = 0;
    // }

    // private void OnCollisionEnter(Collision collision) {
    //     if(collision.transform.tag == playerTag){
    //         Rigidbody otherRB = collision.rigidbody;
    //         //otherRB.AddForce(collision.contacts[0].normal * bounceForce);

    //         otherRB.AddExplosionForce(bounceForce, collision.contacts[0].point, 5);
    //     }
    // }
}
