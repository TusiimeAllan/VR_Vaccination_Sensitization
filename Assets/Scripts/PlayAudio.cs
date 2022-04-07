using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAudio : MonoBehaviour
{
    public AudioSource SoundToPlay;
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player") {
            SoundToPlay.Play();
        } 
    }
 }
