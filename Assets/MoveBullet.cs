using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class MoveBullet : MonoBehaviour
{
    public Vector3 hitPoint;
    public int speed;

    // Start is called before the first frame update
    void Start()
    {
        this.GetComponent<Rigidbody>().AddForce((hitPoint - this.transform.position).normalized * speed);
    }

    void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.tag == "Virus")
        {
            col.gameObject.GetComponent<Health>().currentHealth -= 20;
            Destroy(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }

        Destroy(this.gameObject);
    }
}
