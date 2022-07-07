using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReloadScene : MonoBehaviour
{
    public float delay = 3;
    public string sceneName;
     void Start()
     {
         LoadMe();
     }

     void LoadMe()
     {
        StartCoroutine(LoadLevelAfterDelay(delay));
     }
 
     IEnumerator LoadLevelAfterDelay(float delay)
     {
         yield return new WaitForSeconds(delay);
         SceneManager.LoadScene(sceneName);
         Destroy(gameObject);
     }
}
