using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject spawnedEnemy;

    public GameObject[] spawnPoints;

    public int spawnTime;

    public GameObject enemyPrefab;

    public AudioSource backgroundMusic;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("spawnEnemies", spawnTime);
        backgroundMusic.Play();
  
    }

    void spawnEnemies()
    {// This randomizes the enemy spawn points before they move towards the player
        Invoke("spawnEnemies", spawnTime);
        float randomX = Random.Range(-7, 7);
        float randomY = Random.Range(14, 18);
        float randomZ = Random.Range(30, 35);
        spawnedEnemy = Instantiate(enemyPrefab);
        spawnedEnemy.transform.position = new Vector3(randomX, randomY, randomZ);
    }

    // void spawnEnemies()
    // {// This randomizes the enemy spawn points before they move towards the player
    //     Invoke("spawnEnemies", spawnTime);
        // float randomX = Random.Range(-7, 7);
        // float randomY = Random.Range(14, 18);
        // float randomZ = Random.Range(30, 35);
    //     spawnedEnemy = Instantiate(enemyPrefab);
    //     spawnedEnemy.transform.position = spawnPoints[Random.Range(0, spawnPoints.Length)].transform.position;
    // }
}
