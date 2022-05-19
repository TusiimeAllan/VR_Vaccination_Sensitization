using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomMove : MonoBehaviour
{
    public float speed;
    public GameObject target;
    public float pos1 = 1f;
    public float pos2 = 5f;

    // Start is called before the first frame update
    void Start()
    {
        var rb = GetComponent<Rigidbody>();
        rb.velocity = speed * RandomVector(pos1, pos2);
    }

    private Vector3 RandomVector(float min, float max) {
        var x = Random.Range(min, max);
        var y = Random.Range(min, max);
        var z = Random.Range(min, max);
        return new Vector3(x, y, z);
    }

    void Update()
    {
        target = GameObject.Find("Target");
        float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, target.transform.position, step);
    }

    // private Vector3 RandomVector(float min, float max) {
    //     var x = Random.Range(min, max);
    //     var y = Random.Range(min, max);
    //     var z = Random.Range(min, max);
    //     return new Vector3(x, y, z);
    // }
}
