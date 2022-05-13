using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeController : MonoBehaviour
{
    Scene scene;
    public string SceneOn;
    public GameObject Gun;
    public GameObject Hand;
    public GameObject WhereToClamp;

    void Start() 
    {
        BringGun();
    }

    void Update() 
    {
        BringGun();
        SceneOn = scene.name;
    }
    
    void BringGun()
    {
        scene = SceneManager.GetActiveScene();

        // Check if the name of the current Active Scene is your first Scene.
        if (scene.name == "Inside_Scene")
        {
            WhereToClamp.GetComponent<Valve.VR.InteractionSystem.Hand>().renderModelPrefab = Gun;
        }
        else
        {
            WhereToClamp.GetComponent<Valve.VR.InteractionSystem.Hand>().renderModelPrefab = Hand;
        }
    }
}
