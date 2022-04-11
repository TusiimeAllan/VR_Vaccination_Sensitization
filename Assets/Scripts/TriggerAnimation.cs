using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerAnimation : MonoBehaviour
{
    [SerializeField] private Animator animator;

    [SerializeField] private string animationName;

    private bool play;

    // Start is called before the first frame update
    void Start()
    {
        play = true;
        
    }

    void Update()
    {
        if(play == true){
            StartCoroutine(PlayAnim());
        }
    }

    IEnumerator PlayAnim()
    {
        play = false;
        PlayAnimation();
        yield return new WaitForSeconds(3);
    }

    void PlayAnimation()
    {
        animator.Play(animationName, 0, 3.0f);
    }
    
}
