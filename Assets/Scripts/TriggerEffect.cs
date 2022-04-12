using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerEffect : MonoBehaviour
{
    public Transform particles;
    public bool status;

    void Start()
    {
        status = true;
    }

    void Update()
    {
        if(status == true){
            Produce();
        }else{
            StopProduction();
        }        
    }

    void Produce()
    {
        StartCoroutine(bringParticles());
    }

    IEnumerator bringParticles()
    {
        yield return new WaitForSeconds(1f);
        particles.GetComponent<ParticleSystem>().enableEmission = true;
        status = false;
    }

    void StopProduction()
    {
        StartCoroutine(stopParticles());
    }

    IEnumerator stopParticles()
    {
        particles.GetComponent<ParticleSystem>().enableEmission = false;
        yield return new WaitForSeconds(5f);
        status = true;
    }

}
