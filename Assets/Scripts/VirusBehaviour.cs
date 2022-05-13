using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VirusBehaviour : MonoBehaviour
{
    public ParticleSystem DestroyedEffect;

    [Header("Audio")]
    public RandomPlayer HitPlayer;
    public AudioSource IdleSource;

    void Start()
    {
        if(DestroyedEffect)
            PoolSystem.Instance.InitPool(DestroyedEffect, 16);
        
        if(IdleSource != null)
            IdleSource.time = Random.Range(0.0f, IdleSource.clip.length);
    }

    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<PlayerHealth>().currentHealth -= 5;
            doMagic();
        }
    }

    void doMagic()
    {
        Vector3 position = transform.position;
        
        if(HitPlayer != null)
        {
            HitPlayer.PlayRandom();

            var source = WorldAudioPool.GetWorldSFXSource();
            source.transform.position = position;
            source.pitch = HitPlayer.source.pitch;
            source.PlayOneShot(HitPlayer.GetRandomClip());
        }
           
    }
}
