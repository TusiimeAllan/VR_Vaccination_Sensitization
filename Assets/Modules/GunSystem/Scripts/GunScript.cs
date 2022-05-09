using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Valve.VR.InteractionSystem
{
public class GunScript : MonoBehaviour
{ 
    private Player player = null;

    public SteamVR_Action_Boolean gunTrigger = SteamVR_Input.GetAction<SteamVR_Action_Boolean>("Trigger");
    LineRenderer line;
    float rayLength = 100;

    public GameObject projectile;
    public float power;
    public Transform firepoint;

    [SerializeField]
    LayerMask layerMask;

    public Animator gunFireAnim;
    public ParticleSystem muzzFlash;
    public AudioSource gunShot;

    // Start is called before the first frame update
    void Start()
    {
        line = GetComponent<LineRenderer>();
        gunFireAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        // bool rightHandValid = player.rightHand.currentAttachedObject == null ||
        //             (player.rightHand.currentAttachedObject != null);

        bool rightHandPressed = gunTrigger.GetState(SteamVR_Input_Sources.RightHand);

        bool rightHandReleased = gunTrigger.GetStateUp(SteamVR_Input_Sources.RightHand);

        //This activates the gun to fire and changes the raycast color.
        if (Input.GetKeyDown(KeyCode.G) || OVRInput.GetDown(OVRInput.RawButton.RIndexTrigger) || rightHandPressed)
        {
            Ray ray = new Ray(transform.position, transform.forward);
            RaycastHit hit;
            gunFireAnim.SetBool("TriggerDown", true);
            muzzFlash.Play();
            gunShot.Play();
            if (Physics.Raycast(ray, out hit, rayLength, layerMask))
            {
                line.startColor = Color.blue;
            }

            else
            {
                line.startColor = Color.red;
            }
            // Vector3 direction = new Vector3(0, 0, 1);

            GameObject proj = (GameObject)Instantiate(projectile, firepoint.position, firepoint.rotation);
            proj.GetComponent<Rigidbody>().velocity = firepoint.GetComponent<Transform>().position * power;
        }

        if (Input.GetKeyUp(KeyCode.G) || OVRInput.GetUp(OVRInput.RawButton.RIndexTrigger) || rightHandReleased)
        {
            line.startColor = Color.red;
            gunFireAnim.SetBool("TriggerDown", false);
        }

        line.SetPosition(0, transform.position);
        line.SetPosition(1, transform.position + (transform.forward * rayLength));
    }
}
}