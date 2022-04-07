using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnThem : MonoBehaviour
{
    public GameObject[] characters;
    public GameObject[] spawnPoints;

    public bool spawn = false;

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
        yield return new WaitForSeconds(2);
        produce();
        produce();
        spawn = true;
    }

    public void produce()
    {
        GameObject person = Instantiate(characters[Random.Range(0, characters.Length)], this.transform) as GameObject;
        person.transform.position = spawnPoints[Random.Range(0, spawnPoints.Length)].transform.position;
    }
}
