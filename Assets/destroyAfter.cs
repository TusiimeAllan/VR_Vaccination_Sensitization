using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyAfter : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Respawn")
        {
            Destroy(other.gameObject);
        }
    }

    IEnumerator Kill()
    {
        yield return new WaitForSeconds(9f);
        Destroy(gameObject);
    }
}
