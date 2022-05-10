using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveAi : MonoBehaviour
{
    public GameObject Player;
    public UnityEngine.AI.NavMeshAgent agent;
    // public Transform goal;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag ("Player");

        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        // agent.destination = goal.position; 
         
    }

    void Update() 
    {
        agent.destination = Player.transform.position;
    }

}
