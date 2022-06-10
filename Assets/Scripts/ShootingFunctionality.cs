using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace Valve.VR.InteractionSystem
{
public class ShootingFunctionality : MonoBehaviour
{
    public SteamVR_Action_Boolean gunTrigger = SteamVR_Input.GetAction<SteamVR_Action_Boolean>("Trigger");
    public float accuracy;
    public float maxSpreadAngle;
    public float timeTillMaxSpread;
    public GameObject bullet;
    public GameObject shootPoint;
    public int NumberOfBullets;
    public TextMeshProUGUI bulletNumber;
    public GameObject DeathScreen;

    void Start() {
        //Setting the Number of Bullets on the UI
        bulletNumber.text = NumberOfBullets.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        bool rightHandPressed = gunTrigger.GetStateDown(SteamVR_Input_Sources.RightHand);


        if(Input.GetButton("Fire1") || rightHandPressed)
        {
            if(NumberOfBullets > 0)
            {
                Shoot();
            }else{
                DeathScreen.SetActive(true);
            }
            
            bulletNumber.text = NumberOfBullets.ToString();
        }
    }

    void Shoot()
    {
        RaycastHit hit;
        Quaternion fireRotation = Quaternion.LookRotation(transform.forward);
        float currentSpread = Mathf.Lerp(0.0f, maxSpreadAngle, accuracy / timeTillMaxSpread);
        fireRotation = Quaternion.RotateTowards(fireRotation, Random.rotation, Random.Range(0.0f, currentSpread));

        if(Physics.Raycast(transform.position, fireRotation * Vector3.forward, out hit, Mathf.Infinity))
        {
            GameObject tempBullet = Instantiate(bullet, shootPoint.transform.position, shootPoint.transform.rotation);
            tempBullet.GetComponent<MoveBullet>().hitPoint = hit.point;
        }

        //Reduce the Number of Bullets
        NumberOfBullets--;
    }
}
}