using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using Valve.VR;

public class HandPresence : MonoBehaviour
{
    public bool showController = false;
    public InputDeviceCharacteristics controllerCharacteristics;
    public List<GameObject> controllerPrefabs;
    public GameObject handModelPrefab;

    // [SteamVR_DefaultAction("Squeeze")]
    public SteamVR_Action_Single squeezeAction;

    public SteamVR_Action_Vector2 touchPadAction;

    private InputDevice targetDevice;
    private GameObject spawnedController;
    private GameObject spawnedHandModel;
    private Animator handAnimator;

    // Start is called before the first frame update
    void Start()
    {
        List<InputDevice> devices = new List<InputDevice>();

        InputDevices.GetDevicesWithCharacteristics(controllerCharacteristics, devices);

        foreach(var item in devices)
        {
            Debug.Log(item.name + item.characteristics);
        }    

        if(devices.Count > 0)
        {
            targetDevice = devices[0];
            GameObject prefab = controllerPrefabs.Find(controller => controller.name == targetDevice.name);
            if(prefab)
            {
                spawnedController = Instantiate(prefab, transform);
            }
            else
            {
                Debug.LogError("Did not find corresponding Controller Model");
                spawnedController = Instantiate(controllerPrefabs[0], transform);
            }

            Debug.Log("I am Working");
        }
        else
        {
            spawnedHandModel = Instantiate(handModelPrefab, transform);
            handAnimator = spawnedHandModel.GetComponent<Animator>();
        }
        
    }


    void UpdateHandleAnimation()
    {

        if(targetDevice.TryGetFeatureValue(CommonUsages.trigger, out float triggerValue))
        {
            handAnimator.SetFloat("Trigger", triggerValue);
        }
        else
        {
            handAnimator.SetFloat("Trigger", 0);
        }

        if(targetDevice.TryGetFeatureValue(CommonUsages.grip, out float gripValue))
        {
            handAnimator.SetFloat("Grip", gripValue);
        }
        else
        {
            handAnimator.SetFloat("Grip", 0);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(showController)
        {
            spawnedHandModel.SetActive(false);
            // spawnedController.SetActive(true);
        }
        else
        {
            spawnedHandModel.SetActive(true);
            // UpdateHandleAnimation();
            // Grab_pinch();
            // spawnedController.SetActive(false);
        }

        if(SteamVR_Actions.default_Teleport.GetStateDown(SteamVR_Input_Sources.Any))
        {
            print("Teleport Down");
        }

        if(SteamVR_Actions.default_GrabPinch.GetStateDown(SteamVR_Input_Sources.Any))
        {
            print("Grab_Pinch Up");
        }

        float triggerValue = squeezeAction.GetAxis(SteamVR_Input_Sources.Any);

        if(triggerValue > 0.0f)
        {
            print(triggerValue);
        }

        Vector2 touchpadValue = touchPadAction.GetAxis(SteamVR_Input_Sources.Any);

        if(touchpadValue != Vector2.zero)
        {
            print(touchpadValue);
        }


        //Debugging Stuff
        // if(targetDevice.TryGetFeatureValue(CommonUsages.primaryButton, out bool primaryButtonValue) && primaryButtonValue)
        //     Debug.Log("Pressing Primary Button");

        // if(targetDevice.TryGetFeatureValue(CommonUsages.trigger, out float triggerValue) && triggerValue > 0.1f)
        //     Debug.Log("Trigger Pressed " + triggerValue);

        // if(targetDevice.TryGetFeatureValue(CommonUsages.primary2DAxis, out Vector2 primary2DAxisValue) && primary2DAxisValue != Vector2.zero)
        //     Debug.Log("Primary Touchpad" + primary2DAxisValue);
    }
}
