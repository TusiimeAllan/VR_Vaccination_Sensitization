using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyAfter : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        use();
    }

    void use()
    {
        StartCoroutine(Kill());
    }

    IEnumerator Kill()
    {
        yield return new WaitForSeconds(9f);
        Destroy(gameObject);
    }
}
