using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnVirus : MonoBehaviour
{
    public GameObject[] virus;
    public GameObject[] spawnPoints;

    public bool spawn = false;

    public int NumberOfObjectsToSpawn;
    private int counter;

    void Start()
    {
        makeNumber();
        produce();
    }

    void makeNumber()
    {
        counter = NumberOfObjectsToSpawn;
    }

    void Update()
    {
       if(counter <= 0)
       {
           switchOn();
       }else{
           produce();
       }
    }

    void switchOn()
    {
        
        StartCoroutine(PutOn());
    }

    IEnumerator PutOn()
    {
        yield return new WaitForSeconds(5f);
        makeNumber();
    }

    public void produce()
    {
        while(counter > 0)
        {
            GameObject Virus = Instantiate(virus[Random.Range(0, virus.Length)], this.transform) as GameObject;
            Virus.transform.position = spawnPoints[Random.Range(0, spawnPoints.Length)].transform.position;
            counter--;
        }
    }
}
