using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class npsController : MonoBehaviour{

    public NavMeshAgent agent;

    public GameObject PATH;
    public Transform[] PathPoints;

    public float minDistance = 10;

    public int index = 0;

    void Start(){
        
        agent = GetComponent<NavMeshAgent>();

        PathPoints = new Transform[PATH.transform.childCount];
        for(int i = 0; i < PathPoints.Length; i++){
            PathPoints[i] = PATH.transform.GetChild(i);
        }
    }

    void Update(){
        roam();

        //This is to fix the issue of the agents from floating after being spawned
        if (transform.hasChanged)
        {
            transform.hasChanged = false;
        }else{
            gameObject.GetComponent<NavMeshAgent>().enabled = false;
            gameObject.GetComponent<NavMeshAgent>().enabled = true;
        }
    }

    void roam(){
        if(Vector3.Distance(transform.position, PathPoints[index].position) < minDistance){
            if(index >= 0 && index < PathPoints.Length){
                index += 1;
            }else{
                index = 0;
            }

            if(index == PathPoints.Length){
                index = 0;
            }
        }


        agent.SetDestination(PathPoints[index].position);
    }
}
