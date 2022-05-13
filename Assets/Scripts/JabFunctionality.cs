using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JabFunctionality : MonoBehaviour
{
    public GameObject Player;

    private void Start() 
    {
        Player = GameObject.FindGameObjectWithTag ("Player");
    }
    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag == "Bullet")
        {
            Player.GetComponent<PlayerHealth>().Rejuvenate();
        }
    }
}
