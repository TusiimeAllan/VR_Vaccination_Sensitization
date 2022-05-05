using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Valve.VR.InteractionSystem.Sample
{
    public class PlayVideo : MonoBehaviour
    {
        public GameObject Tutorial;
        public GameObject Disclaimer;
        public GameObject VideoTexture;
        public int TimeToKill;

        public HoverButton hoverButton;

        private void OnButtonDown(Hand hand)
        {
            PlayMyVideo();
        }

        void Start() {
            hoverButton.onButtonDown.AddListener(OnButtonDown);
            Tutorial.SetActive(false);
            Disclaimer.SetActive(false);
            VideoTexture.SetActive(false);
        }

        // Start is called before the first frame update
        void PlayMyVideo()
        {
            Tutorial.SetActive(true);
            Disclaimer.SetActive(true);
            VideoTexture.SetActive(true);

            Destroy(Tutorial, TimeToKill);
            Destroy(VideoTexture, TimeToKill);
            Destroy(Disclaimer, TimeToKill);
        }
    }
}