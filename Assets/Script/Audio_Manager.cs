using UnityEngine;

public class Audio_Manager : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip correct;
    public AudioClip wrong;

    public void Submit_correct()
    {
        if (correct != null)
        {
            audioSource.PlayOneShot(correct, 1f);
        }
    }

    public void Submit_wrong()
    {
        if (wrong != null)
        {
            audioSource.PlayOneShot(wrong, 0.6f);
        }
    }

}
