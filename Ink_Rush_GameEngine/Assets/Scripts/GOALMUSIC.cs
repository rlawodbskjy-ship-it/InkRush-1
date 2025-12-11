using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    public AudioSource bgmSource;
    public AudioClip levelBGM;
    public AudioClip clearBGM;

    void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    public void PlayLevelBGM()
    {
        bgmSource.clip = levelBGM;
        bgmSource.Play();
    }

    public void PlayClearBGM()
    {
        bgmSource.Stop();
        bgmSource.clip = clearBGM;
        bgmSource.Play();
    }

    public void StopBGM()
    {
        bgmSource.Stop();
    }
}
