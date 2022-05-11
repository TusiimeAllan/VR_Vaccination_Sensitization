using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class PlayerHealth : MonoBehaviour
{
    public int currentHealth;
    public TextMeshProUGUI LifeUI;
    public GameObject deadScreen;
    public GameObject lifeScreen;

    void Start()
    {
        currentHealth = 100;
        deadScreen.SetActive(false);
    }

    private void OnTriggerEnter(Collider other) 
    {
        if(other.gameObject.tag == "Virus")
        {

        }
    }

    void Update()
    {
        LifeUI.text = currentHealth.ToString();

        if(currentHealth <= 0)
        {
            deadScreen.SetActive(true);
            Time.timeScale = 0;
        }else{
            deadScreen.SetActive(false);
            lifeScreen.SetActive(true);
        }

        if(deadScreen.active == true)
        {
            lifeScreen.SetActive(false);
        }
    }

    public void Rejuvenate()
    {
        currentHealth = 100;
        Time.timeScale = 1;
    }

    public void AcceptDefeat()
    {
        SceneManager.LoadScene("Kampala_Street");
    }
}
