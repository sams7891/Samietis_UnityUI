using UnityEngine;

public class ButtonClickSoundFX : MonoBehaviour
{
    public AudioClip clip;

    public AudioSource audioSource;

    public void PlaySound()
    {
        audioSource.PlayOneShot(clip);
    }
}
