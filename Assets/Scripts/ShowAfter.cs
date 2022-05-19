using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowAfter : MonoBehaviour
{
    [SerializeField] private float TimeInSeconds;
    [SerializeField] private GameObject[] specimen;
    
    // Start is called before the first frame update
    void Start()
    {
        for(int i=0; i<specimen.Length; i++)
        {
            specimen[i].SetActive(false);
        }
        
        StartCoroutine(ShowMe());
    }

    IEnumerator ShowMe()
    {
        yield return new WaitForSeconds(TimeInSeconds);
        for(int i=0; i<specimen.Length; i++)
        {
            specimen[i].SetActive(true);
        }
    }

}
