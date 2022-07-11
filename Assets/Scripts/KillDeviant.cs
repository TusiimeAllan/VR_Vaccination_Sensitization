using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillDeviant : MonoBehaviour
{
    [SerializeField]
    private string deviantName;
    private GameObject Deviant;

    void Update()
    {
        if (GameObject.Find(deviantName) != null)
        {
            Deviant = GameObject.Find(deviantName);
            Deviant.SetActive(false);
        }
    }
}
