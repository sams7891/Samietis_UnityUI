using UnityEngine;

public class SceneTransitionTrigger : MonoBehaviour
{
    public Animator animator;

    public void PlaySceneChange()
    {
        animator.Play("SceneChangeAnimation");
    }
}
