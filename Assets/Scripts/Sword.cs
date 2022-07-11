using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour
{
    public AudioSource audio;
    void OnCollisionEnter(Collision collision) {
        if(collision.gameObject.tag == "Virus"){
            audio.Play();
            collision.gameObject.GetComponent<Health>().decreaseHealth(20);
        }
    }
}
