using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    public string nextScene;

    public void OnAnimationEnd()
    {
        SceneManager.LoadScene(nextScene);
    }
}
