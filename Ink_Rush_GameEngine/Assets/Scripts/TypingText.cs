using TMPro;
using UnityEngine;
using System.Collections;

public class TypingText : MonoBehaviour
{
    public TextMeshProUGUI textUI;
    public string message;
    public float typingSpeed = 0.05f;

    [Header("Typing Sound")]
    public AudioSource audioSource;     // 🔊 타이핑 소리 재생용
    public float soundVolume = 1f;      // 🔊 소리 크기

    Coroutine typingRoutine;

    void OnEnable()
    {
        StartTyping();
    }

    public void StartTyping()
    {
        if (typingRoutine != null)
            StopCoroutine(typingRoutine);

        typingRoutine = StartCoroutine(Play());
    }

    IEnumerator Play()
    {
        textUI.text = "";

        foreach (char c in message)
        {
            textUI.text += c;

            // 🔊 사운드 재생 (속도에 맞춰 한 번만 재생)
            if (audioSource != null)
            {
                audioSource.volume = soundVolume;
                audioSource.Play();  // typingSpeed보다 빠르지 않게 Play만 호출
            }

            yield return new WaitForSeconds(typingSpeed);
        }
    }
}
