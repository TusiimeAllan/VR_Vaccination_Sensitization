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

        public SteamVR_Action_Boolean BringGun = SteamVR_Input.GetAction<SteamVR_Action_Boolean>("GrabPinch");

        public float m_Sensitivity = 0.1f;
        public float m_MaxSpeed = 1.0f;

        // public SteamVR_Action_Boolean m_MovePress = null;
        // public SteamVR_Action_Vector2 m_MoveValue = null;

        public SteamVR_Input_Sources handType;
        public SteamVR_Action_Boolean grabGripAction = SteamVR_Input.GetAction<SteamVR_Action_Boolean>("GrabGrip");

        private float m_Speed;

        private CharacterController m_CharacterController = null;

        [SerializeField]
        private Rigidbody rb;

        [Space]
        [Header( "Our Requirements" )]
		private Hand pointerHand = null;
		private Player player = null;

		private bool visible = false;

        [Header( "Camera" )]
        public Transform cameraTransform;
        public Vector3 moveDirection;
        public float moveSpeed = 2.0f;

        void Start()
        {

			player = InteractionSystem.Player.instance;

			if ( player == null )
			{
				Debug.LogError("<b>[SteamVR Interaction]</b> Teleport: No Player instance found in map.", this);
				Destroy( this.gameObject );
				return;
			}

            rb = GetComponent<Rigidbody>();
		}


        void FixedUpdate()
		{

            bool rightHandValid = player.rightHand.currentAttachedObject == null ||
                    (player.rightHand.currentAttachedObject != null);

            bool leftHandValid = player.leftHand.currentAttachedObject == null ||
                    (player.leftHand.currentAttachedObject != null);

            bool rightHandPressed = TranslatePlayer.GetState(SteamVR_Input_Sources.RightHand) && rightHandValid;
            bool leftHandPressed = TranslatePlayer.GetState(SteamVR_Input_Sources.LeftHand) && leftHandValid;

            bool rightHandReleased = TranslatePlayer.GetStateUp(SteamVR_Input_Sources.RightHand) && rightHandValid;
            bool leftHandReleased = TranslatePlayer.GetStateUp(SteamVR_Input_Sources.LeftHand) && leftHandValid;

            Vector3 lookDirection = new Vector3(cameraTransform.forward.x, 0, cameraTransform.forward.z);
            moveDirection = lookDirection * moveSpeed * Time.deltaTime;

            bool gunOn = grabGripAction.GetStateDown(SteamVR_Input_Sources.RightHand);

            

            
                if(leftHandPressed)
                {
                    ReversePlayer();
                    Debug.Log("LeftHand Button Pressed");
                }

                if(rightHandPressed)
                {
                    // CalculateMovement();
                    MovePlayer();
                    Debug.Log("RightHand Button Pressed");
                }

                if(gunOn)
                {
                    // CalculateMovement();
                    // MovePlayer();
                    Debug.Log("Gun Requested");
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

        void OnTriggerEnter(Collider other)
        {
            if(other.gameObject.tag == "Obstacle"){
                ReversePlayer();
            }            
        }

        private void MovePlayer()
        {
            rb.MovePosition(transform.position + moveDirection);
            // transform.localPosition += moveDirection;
        }

        private void ReversePlayer()
        {
            rb.MovePosition(transform.position - moveDirection);
            // transform.localPosition -= moveDirection;
        }
        
    }

}