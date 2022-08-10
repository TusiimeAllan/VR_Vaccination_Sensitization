using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Virus_Spawner : MonoBehaviour
{
    [SerializeField] private GameObject[] ObjectsToSpawn;
    [SerializeField] private GameObject[] spawnPoints;
    [SerializeField] private GameObject spawnedEnemy;
    [SerializeField] private int ViralLoad;
    [SerializeField] private float spawnDelay;

    [Space]
    public VirusWar Logic;
    private int Level;

    private int counter = 10;

    void Start() 
    {
        
    }

    void Update()
    {
        Level = Logic.WaveLevel;

        if(Logic.spawn){
            FireWave(ViralLoad);
        }else{
            Debug.Log("Battalion is waiting for orders ! ");
        }
    }

    void FireWave(int viralLoad)
    {
        switch(Level)
        {
            case 1:
            wave(viralLoad);
            break;

            case 2:
            wave(viralLoad * 2);
            break;

            case 3:
            wave(viralLoad * 3);
            break;

            case 4:
            wave(viralLoad * 4);
            break;

            case 5:
            wave(viralLoad * 5);
            break;

            case 6:
            wave(viralLoad * 6);
            break;
            
            case 7:
            wave(viralLoad * 7);
            break;

            case 8:
            wave(viralLoad * 8);
            break;

            case 9:
            wave(viralLoad * 9);
            break;

            case 10:
            wave(viralLoad * 10);
            break;

            case 11:
            wave(viralLoad * 11);
            break;

            case 12:
            wave(viralLoad * 12);
            break;

            case 13:
            wave(viralLoad * 13);
            break;

            case 14:
            wave(viralLoad * 14);
            break;

            case 15:
            wave(viralLoad * 15);
            break;

            case 16:
            wave(viralLoad * 16);
            break;

            case 17:
            wave(viralLoad * 17);
            break;
            
            case 18:
            wave(viralLoad * 18);
            break;

            case 19:
            wave(viralLoad * 19);
            break;

            case 20:
            wave(viralLoad * 20);
            break;

            case 21:
            wave(viralLoad * 21);
            break;

            case 22:
            wave(viralLoad * 22);
            break;

            case 23:
            wave(viralLoad * 23);
            break;

            case 24:
            wave(viralLoad * 24);
            break;

            case 25:
            wave(viralLoad * 25);
            break;

            case 26:
            wave(viralLoad * 26);
            break;

            case 27:
            wave(viralLoad * 27);
            break;

            case 28:
            wave(viralLoad * 28);
            break;

            case 29:
            wave(viralLoad * 29);
            break;

            case 30:
            wave(viralLoad * 30);
            break;

            default:
            wave(viralLoad * 20);
            break;
        }
    }

    void wave(int load)
    {
        for(int i = 0; i < load; i++){
            Invoke("produce", spawnDelay);
        }

        Logic.spawn = false;
    }

    void produce()
    {
        spawnedEnemy = Instantiate(ObjectsToSpawn[Random.Range(0, ObjectsToSpawn.Length)]);
        spawnedEnemy.transform.position = spawnPoints[Random.Range(0, spawnPoints.Length)].transform.position;
    }
}
