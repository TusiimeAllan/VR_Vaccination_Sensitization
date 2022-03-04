using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using TMPro;
 
public class Normal_Locomotion : MonoBehaviour {
 
    public InputAction moveStick;
    public GameObject objToMove;
    public TextMeshProUGUI debugText;
 
    private void OnEnable()
    {
        moveStick.Enable();
    }
    private void OnDisable()
    {
        moveStick.Disable();
    }
    private void Awake()
    {
        moveStick.started += OnMoveStick;
        moveStick.canceled += OnMoveStick;
    }
 
 
    public void OnMoveStick(InputAction.CallbackContext context){
        debugText.text = "On Move Stick - moved! \nValue type:" + context.valueType + ", \nPhase type: " + context.phase;
       var contextResult = context.ReadValue<Vector2>();
 
            if (context.started)
            {
                debugText.text = "Context Started: Y = " + contextResult.y.ToString() + ", X = " + contextResult.x.ToString();
                objToMove.transform.Translate (0, 0, contextResult.y);
                objToMove.transform.Rotate(0, contextResult.x, 0);
            }
            else if (context.canceled)
            {
                debugText.text = "Context Cancelled";
            }
        }
}