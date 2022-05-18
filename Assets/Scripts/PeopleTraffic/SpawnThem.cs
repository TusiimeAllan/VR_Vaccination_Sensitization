using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnThem : MonoBehaviour
{
    public GameObject[] characters;
    public GameObject[] spawnPoints;

    public bool spawn = false;

    public int NumberOfObjectsToSpawn;
    private int counter = 0;

    void Start()
    {
        SpawnRandomPerson();
    }

    void Update()
    {
        if(spawn == true){
            SpawnRandomPerson();
        }
    }

    public void SpawnRandomPerson()
    {
        spawn = false;
        StartCoroutine(SpawnAfterTime());
    }

    IEnumerator SpawnAfterTime()
    {
        if(counter < NumberOfObjectsToSpawn){
            yield return new WaitForSeconds(2);
            produce();
            produce();
            spawn = true;
        }else{
            spawn = false;
        }
        
    }

    public void produce()
    {
        GameObject person = Instantiate(characters[Random.Range(0, characters.Length)], this.transform) as GameObject;
        person.transform.position = spawnPoints[Random.Range(0, spawnPoints.Length)].transform.position;
        counter++;
    }
}