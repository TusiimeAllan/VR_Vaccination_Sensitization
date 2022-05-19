using System.Drawing;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpriteBlink : MonoBehaviour
{
    public Image pic;
    [SerializeField] private float BlinkFadeInTime = 0.5f;
    [SerializeField] private float BlinkStayTime = 0.8f;
    [SerializeField] private float BlinkFadeOutTime = 0.7f;
    private float _timeChecker = 0;
    private Color _color;

    void Start()
    {

        pic = GetComponent<Image>();
        _color = pic.color;
    }


    // Update is called once per frame
    void Update()
    {

        _timeChecker += Time.deltaTime;
        if(_timeChecker < BlinkFadeInTime)
        {
            pic.color = new Color(_color.r, _color.g, _color.b, _timeChecker / BlinkFadeInTime);
        
        }else if(_timeChecker < BlinkFadeInTime + BlinkStayTime)
        {
            pic.color = new Color(_color.r, _color.g, _color.b, 1);

        }else if(_timeChecker < BlinkFadeInTime + BlinkStayTime + BlinkFadeOutTime)
        {
            pic.color = new Color(_color.r, _color.g, _color.b, 1 - (_timeChecker - (BlinkFadeInTime + BlinkFadeInTime))/BlinkFadeOutTime);

        }else{
            _timeChecker = 0;
        }
    }

}

//This makes UI Elements blink in Unity
