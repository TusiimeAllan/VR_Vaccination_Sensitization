using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyBehavior : MonoBehaviour
{
    Animator flightAnim;
    public Transform Player;
    [SerializeField] int MoveSpeed = 4;
    int MaxDist = 100;
    int MinDist = 10;
    
    
    
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindWithTag("Player").transform; 
        
    }

    // Update is called once per frame
    void Update()
    {//this code causes the enemy to approach the player.
        if (Vector3.Distance(transform.position, Player.position) >= MinDist)
        {
            transform.position -= transform.forward * MoveSpeed * Time.deltaTime;
            transform.position -= transform.up * MoveSpeed * Time.deltaTime;

            if (Vector3.Distance(transform.position, Player.position) <= MaxDist)
            {
          
            }
        }   
    }
}