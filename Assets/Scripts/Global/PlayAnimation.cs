using UnityEngine;

public class TransitionTrigger : MonoBehaviour
{
    public Animator animator; 
    public string animationName;
    public void PlayTransition()
    {
        animator.Play(animationName);
    }
}
