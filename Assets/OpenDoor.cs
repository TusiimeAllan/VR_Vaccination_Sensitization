using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    [SerializeField]
    private Animator Door;

    [SerializeField]
    private AudioSource audioSource; 

    [SerializeField]
    private Animator NurseController;

    void Start() {

        NurseController.SetBool("Talk", false);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) {
        Door.SetBool("OpenDoor", true);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player")) {
        Door.SetBool("OpenDoor", false);
        NurseController.SetBool("Talk", true);
        PlayNurseVoice();
        }
    }

    void PlayNurseVoice()
    {
        audioSource.Play();
    }
}
