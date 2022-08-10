using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VirusWar : MonoBehaviour
{
    public Virus_Spawner SpawnLogic;
    public PlayerHealth playerHealth;
    public int WaveLevel; 

    public bool spawn = false;

    void Start()
    {
        WaveLevel = 1;
    }

    public void Testing()
    {
        Debug.Log("Player Health: " + playerHealth.currentHealth );
    }
}
