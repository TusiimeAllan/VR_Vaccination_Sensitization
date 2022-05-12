using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Valve.VR.InteractionSystem.Sample
{
public class SceneTransition : MonoBehaviour
{
    public string levelName;
    public string previousLevel;

    public HoverButton hoverButton;

    // Start is called before the first frame update
    void Start()
    {
        hoverButton.onButtonDown.AddListener(OnButtonDown);
    }

    private void OnButtonDown(Hand hand)
    {
        StartCoroutine(LoadLevelAsync());
    }

    private IEnumerator LoadLevelAsync()
    {
        var progress = SceneManager.LoadSceneAsync(levelName, LoadSceneMode.Additive);

        while (!progress.isDone)
        {
            yield return null;
        }

        Debug.Log("Next Level Loaded");
        Debug.Log("Previous Level Removed");

        yield return new WaitForSeconds(1f);
        var Unloading = SceneManager.UnloadSceneAsync(previousLevel);

        while(!Unloading.isDone)
        {
            yield return null;
        }

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    } 
}
}
