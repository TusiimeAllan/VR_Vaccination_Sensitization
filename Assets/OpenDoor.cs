using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    [SerializeField]
    private GameObject Door;

    [SerializeField]
    private string Animation;
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) {
        GetComponent<Animator>().SetTrigger("OpenDoor");
    }
    }
}
