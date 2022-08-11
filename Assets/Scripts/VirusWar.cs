using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VirusWar : MonoBehaviour
{
    [Header("External Scripts")]
    public Virus_Spawner SpawnLogic;
    public PlayerHealth playerHealth;
    public int WaveLevel; 

    public bool spawn = false;

    void Start()
    {
        CalculateLevel();
        spawn = true;
    }

    public void Testing()
    {
        Debug.Log("Player Health: " + playerHealth.currentHealth );
    }

    private void CalculateLevel()
    {
        WaveLevel = 1;
    }

    void LateUpdate()
    {
        Debug.Log("Number: " + SpawnLogic.VirusCount);
    }
}
