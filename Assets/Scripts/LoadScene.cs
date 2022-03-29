using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    public string levelName;

    public void GoToScene()
    {
        SceneManager.LoadScene(levelName);
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
    } 
}
