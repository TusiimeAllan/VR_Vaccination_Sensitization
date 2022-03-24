using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class customPedestrianSpawner : MonoBehaviour{

    private Transform[] waypoints;

    public GameObject[] pedestrian;

    public int amount;

    public GameObject[] spawnedAi;

    void Start(){
        loadArray();
        spawnPrefab();
    }

    void loadArray(){
        spawnedAi = new GameObject[amount];
        waypoints = new Transform[gameObject.transform.childCount];
        for(int i = 0; i < waypoints.Length; i++){
            waypoints[i] = gameObject.transform.GetChild(i);
        }
    }

    void spawnPrefab(){
        for(int i = 0; i < amount; i++){
            int e = Random.Range(0, waypoints.Length);

            spawnedAi[i] = Instantiate(pedestrian[Random.Range(0, pedestrian.Length)]);
            // spawnedAi[i].GetComponent<ThirdPersonUserControl>().currentWaypoint = waypoints[e].GetComponent<waypoint>();
            spawnedAi[i].transform.position = waypoints[e].transform.position;
        }
    }
}