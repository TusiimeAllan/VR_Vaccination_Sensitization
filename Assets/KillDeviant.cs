using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillDeviant : MonoBehaviour
{
    public string deviantName;
    public GameObject Deviant;

    void Update()
    {
        if (GameObject.Find(deviantName) != null)
        {
            Deviant = GameObject.Find(deviantName);
            Deviant.SetActive(false);
        }
    }
}
