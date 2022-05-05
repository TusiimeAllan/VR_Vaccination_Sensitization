using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RBC_Spawner : MonoBehaviour
{
    public GameObject[] ObjectsToSpawn;
    public GameObject[] spawnPoints;

    public bool spawn = false;

    public int NumberOfObjectsToSpawn;
    private int counter = 10;

    void Update()
    {
        produce();
    }

    public void produce()
    {
        GameObject Virus = Instantiate(ObjectsToSpawn[Random.Range(0, ObjectsToSpawn.Length)], this.transform) as GameObject;
        Virus.transform.position = spawnPoints[Random.Range(0, spawnPoints.Length)].transform.position;
        counter++;
    }
}
