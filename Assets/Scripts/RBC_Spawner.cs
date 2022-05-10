using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RBC_Spawner : MonoBehaviour
{
    public GameObject[] ObjectsToSpawn;
    public GameObject[] spawnPoints;
    public GameObject spawnedEnemy;
    public float spawnTime;
    public bool spawn = false;

    public int NumberOfObjectsToSpawn;
    private int counter = 10;
    // public Vector3 Point;

    void Start() 
    {
        Invoke("spawnEnemies", spawnTime);
    }

    void Update()
    {
        // produce();
    }

    void spawnEnemies()
    {// This randomizes the enemy spawn points before they move towards the player
        Invoke("spawnEnemies", spawnTime);
        // float randomX = Random.Range(-(Point.x), Point.x);
        // float randomY = Random.Range(-(Point.y), Point.y);
        // float randomZ = Random.Range(-(Point.z), Point.z);
        spawnedEnemy = Instantiate(ObjectsToSpawn[Random.Range(0, ObjectsToSpawn.Length)]);
        // spawnedEnemy.transform.position = new Vector3(randomX, randomY, randomZ);
        spawnedEnemy.transform.position = spawnPoints[Random.Range(0, spawnPoints.Length)].transform.position;
    }

    // public void produce()
    // {
    //     GameObject Virus = Instantiate(ObjectsToSpawn[Random.Range(0, ObjectsToSpawn.Length)], this.transform) as GameObject;
    //     Virus.transform.position = spawnPoints[Random.Range(0, spawnPoints.Length)].transform.position;
    //     counter++;
    // }
}
