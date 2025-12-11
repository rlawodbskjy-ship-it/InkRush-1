using UnityEngine;

public class UIAudioManager : MonoBehaviour
{
    public static UIAudioManager Instance;  // 🔥 싱글톤

    public AudioSource audioSource;
    public AudioClip clickSound;

    void Awake()
    {
        // 싱글톤 세팅
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    public void PlayClickSound()
    {
        if (audioSource != null && clickSound != null)
            audioSource.PlayOneShot(clickSound);
    }
}
