//======= All rights reserved. ===============
//
// Purpose: Handles all the TRanslate logic
//
//=============================================================================

using UnityEngine;
using UnityEngine.Events;
using System.Collections;

namespace Valve.VR.InteractionSystem
{
	//-------------------------------------------------------------------------
	public class Translate : MonoBehaviour
    {
        public SteamVR_Action_Boolean TranslatePlayer = SteamVR_Input.GetAction<SteamVR_Action_Boolean>("Teleport");

        public float m_Sensitivity = 0.1f;
        public float m_MaxSpeed = 1.0f;

        public SteamVR_Action_Boolean m_MovePress = null;
        public SteamVR_Action_Vector2 m_MoveValue = null;
        public float move = 1;

        public SteamVR_Input_Sources handType;
        public SteamVR_Action_Boolean grabGripAction = SteamVR_Input.GetAction<SteamVR_Action_Boolean>("GrabGrip");

        private float m_Speed;

        private CharacterController m_CharacterController = null;

        [Header( "Our Requirements" )]
		private Hand pointerHand = null;
		private Player player = null;

		private bool visible = false;

        void Start()
        {

			player = InteractionSystem.Player.instance;

			if ( player == null )
			{
				Debug.LogError("<b>[SteamVR Interaction]</b> Teleport: No Player instance found in map.", this);
				Destroy( this.gameObject );
				return;
			}
		}


        void Update()
		{

            bool rightHandValid = player.rightHand.currentAttachedObject == null ||
                    (player.rightHand.currentAttachedObject != null);

            bool leftHandValid = player.leftHand.currentAttachedObject == null ||
                    (player.leftHand.currentAttachedObject != null);

            bool rightHandPressed = TranslatePlayer.GetState(SteamVR_Input_Sources.RightHand) && rightHandValid;
            bool leftHandPressed = TranslatePlayer.GetStateDown(SteamVR_Input_Sources.LeftHand) && leftHandValid;

            bool rightHandReleased = TranslatePlayer.GetStateUp(SteamVR_Input_Sources.RightHand) && rightHandValid;
            bool leftHandReleased = TranslatePlayer.GetStateUp(SteamVR_Input_Sources.LeftHand) && leftHandValid;

            
                if(leftHandPressed)
                {
                    Debug.Log("LeftHand Button Pressed");
                }

                if(rightHandPressed)
                {
                    CalculateMovement();
                    Debug.Log("RightHand Button Pressed");
                }

            
                if(leftHandReleased)
                {
                    Debug.Log("LeftHand Button Released");
                }

                if(rightHandReleased)
                {
                    Debug.Log("RightHand Button Released");
                }
		}

        
        private void CalculateMovement()
        {
            //Figure Out Movement Orientation
            Vector3 orientationEuler = new Vector3(0, transform.eulerAngles.y, 0);
            Quaternion orientation = Quaternion.Euler(orientationEuler);
            Vector3 movement = Vector3.zero;

            // Add then Clamp
            m_Speed += move * m_Sensitivity;
            m_Speed = Mathf.Clamp(m_Speed, -m_MaxSpeed, m_MaxSpeed);

            //Orientation
            movement += orientation * (m_Speed * Vector3.forward) * Time.deltaTime;

            // Apply
            m_CharacterController.Move(movement);

        }

        

        private void Awake()
        {
            m_CharacterController = GetComponent<CharacterController>();
        }

        public void TestingGrab()
        {
            if(grabGripAction.GetStateDown(handType))
            {
                Debug.Log("They have Pressed me!");
            }
        }
        
    }

}