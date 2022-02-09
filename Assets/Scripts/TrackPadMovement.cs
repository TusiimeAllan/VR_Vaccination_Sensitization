using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class TrackPadMovement : MonoBehaviour
{

    public float m_Sensitivity = 0.1f;
    public float m_MaxSpeed = 1.0f;

    public SteamVR_Action_Boolean m_MovePress = null;
    public SteamVR_Action_Vector2 m_MoveValue = null;

    public SteamVR_Input_Sources handType;
    public SteamVR_Action_Boolean grabGripAction = SteamVR_Input.GetAction<SteamVR_Action_Boolean>("GrabGrip");

    private float m_Speed;

    private CharacterController m_CharacterController = null;
    private Transform m_CameraRig = null;
    private Transform m_Head = null;

    private void Awake()
    {
        m_CharacterController = GetComponent<CharacterController>();
    }
    

    private void Start()
    {
        m_CameraRig = SteamVR_Render.Top().origin;
        m_Head = SteamVR_Render.Top().head;        
    }

    public void TestingGrab()
    {
        if(grabGripAction.GetStateDown(handType))
        {
            Debug.Log("They have Pressed me!");
        }
    }
    

    private void Update()
    {
        // HandleHead();
        // HandleHeight();
        CalculateMovement();
    }

    private void HandleHead()
    {
        //Store Current Values
        Vector3 oldPosition = m_CameraRig.position;
        Quaternion oldRotation = m_CameraRig.rotation;

        //Rotation
        transform.eulerAngles = new Vector3(0.0f, m_Head.rotation.eulerAngles.y, 0.0f);

        //Restore the Values
        m_CameraRig.position = oldPosition;
        m_CameraRig.rotation = oldRotation;
    }


    private void CalculateMovement()
    {
        //Figure Out Movement Orientation
        Vector3 orientationEuler = new Vector3(0, transform.eulerAngles.y, 0);
        Quaternion orientation = Quaternion.Euler(orientationEuler);
        Vector3 movement = Vector3.zero;

        //If not Moving
        if(m_MovePress.GetStateUp(SteamVR_Input_Sources.Any))
            m_Speed = 0;

        //If button Pressed
        if(m_MovePress.state)
        {
            // Add then Clamp
            m_Speed += m_MoveValue.axis.y * m_Sensitivity;
            m_Speed = Mathf.Clamp(m_Speed, -m_MaxSpeed, m_MaxSpeed);

            //Orientation
            movement += orientation * (m_Speed * Vector3.forward) * Time.deltaTime;
        }

        // Apply
        m_CharacterController.Move(movement);

    }


    private void HandleHeight()
    {
        //Get the Head in local Space
        float headHeight = Mathf.Clamp(m_Head.localPosition.y, 1, 2);
        m_CharacterController.height = headHeight;

        //Cut in Half
        Vector3 newCenter = Vector3.zero;
        newCenter.y = m_CharacterController.height / 2;
        newCenter.y += m_CharacterController.skinWidth;

        //Move Capsule in LocalSpace
        newCenter.x = m_Head.localPosition.x;
        newCenter.z = m_Head.localPosition.z;

        //Rotate
        newCenter = Quaternion.Euler(0, -transform.eulerAngles.y, 0) * newCenter;

        //Apply
        m_CharacterController.center = newCenter;
    }
}
