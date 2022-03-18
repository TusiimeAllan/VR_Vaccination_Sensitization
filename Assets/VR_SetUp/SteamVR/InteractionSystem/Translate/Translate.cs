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

        [Header( "Camera" )]
        public Transform cameraTransform;
        public Vector3 moveDirection;
        public float moveSpeed = 0.05f;

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
            bool leftHandPressed = TranslatePlayer.GetState(SteamVR_Input_Sources.LeftHand) && leftHandValid;

            bool rightHandReleased = TranslatePlayer.GetStateUp(SteamVR_Input_Sources.RightHand) && rightHandValid;
            bool leftHandReleased = TranslatePlayer.GetStateUp(SteamVR_Input_Sources.LeftHand) && leftHandValid;

            Vector3 lookDirection = new Vector3(cameraTransform.forward.x, 0, cameraTransform.forward.z);
            moveDirection = lookDirection * moveSpeed;

            

            
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

            
                if(leftHandReleased)
                {
                    Debug.Log("LeftHand Button Released");
                }

                if(rightHandReleased)
                {
                    Debug.Log("RightHand Button Released");
                }
		}

        private void MovePlayer()
        {
            transform.localPosition += moveDirection;
        }

        private void ReversePlayer()
        {
            transform.localPosition -= moveDirection;
        }
        
    }

}