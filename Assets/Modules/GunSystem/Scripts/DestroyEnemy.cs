using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DestroyEnemy : MonoBehaviour
{
    float rayLength = 100;

    [SerializeField]
    LayerMask layerMask;
    public int scoreNum;
    public ParticleSystem death;
    public Text scoreText;
    public AudioSource Destruction;

    // Update is called once per frame
    void Update()
    { //This is a complement to the GunScript code for actual enemy destruction
        if (Input.GetKeyDown(KeyCode.G) || OVRInput.Get(OVRInput.RawButton.RIndexTrigger))
        {
            Ray ray = new Ray(transform.position, transform.forward);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, rayLength, layerMask))
            {
                
                deathFunction();
                Destruction.Play();
            }
        }
    }
    
   public void deathFunction()
    { //This function causes the animations to play for the death of the enemy and updates the score
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;
        scoreNum += 1;
        scoreText.text = "Score: " + scoreNum;
        if (Physics.Raycast(ray, out hit, rayLength, layerMask))
        {
            
            death.transform.position = hit.transform.position;
            death.Play();
            Destroy(hit.transform.gameObject, .1f);
              
          
        }
    }
}
