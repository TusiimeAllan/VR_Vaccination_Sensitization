using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomMove : MonoBehaviour
{
    [SerializeField]
    private float speed, pos1 = 1f, pos2 = 5f;

    [Space]
    [SerializeField]
    private GameObject target;

    // Start is called before the first frame update
    void Start()
    {
        var rb = GetComponent<Rigidbody>();
        rb.velocity = speed * RandomVector(pos1, pos2);

        target = GameObject.FindGameObjectWithTag("Target");
    }

    private Vector3 RandomVector(float min, float max) {
        var x = Random.Range(min, max);
        var y = Random.Range(min, max);
        var z = Random.Range(min, max);
        return new Vector3(x, y, z);
    }

    void Update()
    {
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
