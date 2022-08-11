using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VirusWar : MonoBehaviour
{
    [Header("External Scripts")]
    public Virus_Spawner SpawnLogic;
    public PlayerHealth playerHealth;
    public int WaveLevel = 0; 

    public bool spawn = false;

    private int ViralLoad;

    void Start()
    {
        ViralLoad = 0;

        CalculateLevel();
    }

    public void Testing()
    {
        Debug.Log("Player Health: " + playerHealth.currentHealth );
    }

    private void CalculateLevel()
    {
        if(WaveLevel == 0){
            Spawn();
        }else if(ViralLoad < 2) {
            Spawn();
        }
    }

    void Update()
    {
        ViralLoad = GameObject.FindGameObjectsWithTag("Virus").Length;
    }

    void LateUpdate()
    {
        Debug.Log("Number of Viruses: " + ViralLoad );
    }

    void Spawn()
    {
        WaveLevel++;
        spawn = true;
    }
}
