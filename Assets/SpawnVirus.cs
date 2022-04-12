using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnVirus : MonoBehaviour
{
    public GameObject[] virus;
    public GameObject[] spawnPoints;

    public bool spawn = false;

    public int NumberOfObjectsToSpawn;
    private int counter = 10;

    void Start()
    {
        spawn = true;
    }

    void Update()
    {
        if(spawn == true){
            produce();
            WaitAbit();
        }else{
            switchOn();
        }
    }

    void WaitAbit()
    {
        StartCoroutine(PutOff());
    }

    IEnumerator PutOff()
    {
        yield return new WaitForSeconds(3f);
        spawn = false;
    }

    void switchOn()
    {
        StartCoroutine(PutOn());
    }

    IEnumerator PutOn()
    {
        yield return new WaitForSeconds(5f);
        spawn = true;
    }

    public void produce()
    {
        GameObject Virus = Instantiate(virus[Random.Range(0, virus.Length)], this.transform) as GameObject;
        Virus.transform.position = spawnPoints[Random.Range(0, spawnPoints.Length)].transform.position;
        counter++;
    }
}
