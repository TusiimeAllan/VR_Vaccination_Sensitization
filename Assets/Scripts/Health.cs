using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int currentHealth;

    // Update is called once per frame
    void Update()
    {
        if(currentHealth <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    public void decreaseHealth(int damage)
    {
        currentHealth -= damage;
    }
}
