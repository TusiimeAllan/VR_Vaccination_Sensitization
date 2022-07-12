using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReloadScene : MonoBehaviour
{
    public float delay = 2f;
    public string sceneName;
    public float check = 0.0f;
     void Start()
     {
        check = PlayerPrefs.GetFloat("check");
        LoadMe(check);
     }

     void LoadMe(float checker)
     {
        if(checker != 1)
        {
            StartCoroutine(LoadLevelAfterDelay(delay));
        }
        
     }
 
     IEnumerator LoadLevelAfterDelay(float delay)
     {
         yield return new WaitForSeconds(delay);
         PlayerPrefs.SetFloat("check", 1f);
         SceneManager.LoadScene(sceneName);
         
     }
}
