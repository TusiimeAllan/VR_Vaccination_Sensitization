using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideBoy : MonoBehaviour
{
    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag == "Virus"){
            other.gameObject.SetActive(false);
        }
    }
}
