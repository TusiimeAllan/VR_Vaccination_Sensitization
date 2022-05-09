using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Valve.VR.InteractionSystem
{
public class Gun : MonoBehaviour
{
    private Player player = null;
    public GameObject projectile;
    public float power;
    public Transform firepoint;

    public SteamVR_Action_Boolean gunTrigger = SteamVR_Input.GetAction<SteamVR_Action_Boolean>("Trigger");

    public SteamVR_Action_Boolean grabGripAction = SteamVR_Input.GetAction<SteamVR_Action_Boolean>("GrabGrip");

    public bool automatic;
    public float cooldownTime;
    float time;

    void Update()
    {
        // bool rightHandValid = player.rightHand.currentAttachedObject == null ||
        //             (player.rightHand.currentAttachedObject != null);

        bool rightHandPressed = gunTrigger.GetState(SteamVR_Input_Sources.RightHand);

        bool rightHandReleased = gunTrigger.GetStateUp(SteamVR_Input_Sources.RightHand);

        bool gunOn = grabGripAction.GetStateDown(SteamVR_Input_Sources.RightHand);


        if (time > 0f)
        {
            time -= Time.deltaTime;
        }
        else
        {
            if (gunOn && rightHandPressed)
            {
                time = cooldownTime;
                GameObject proj = (GameObject)Instantiate(projectile, firepoint.position, firepoint.rotation);
                proj.GetComponent<Rigidbody>().velocity = firepoint.forward * power;
            }
        }
    }
}
}