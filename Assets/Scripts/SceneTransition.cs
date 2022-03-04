using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Valve.VR.InteractionSystem.Sample
{
public class SceneTransition : MonoBehaviour
{
    public string SceneToLoad;
    public HoverButton hoverButton;

    // Start is called before the first frame update
    void Start()
    {
        hoverButton.onButtonDown.AddListener(OnButtonDown);
    }

    private void OnButtonDown(Hand hand)
    {
        StartCoroutine(ChangeScene());
    }

   private IEnumerator ChangeScene()
    {
        yield return new WaitForSeconds(1);

        SceneManager.LoadScene(SceneToLoad);
    }
}
}
