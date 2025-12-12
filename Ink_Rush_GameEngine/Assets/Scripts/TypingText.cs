using TMPro;
using UnityEngine;
using System.Collections;

public class TypingText : MonoBehaviour
{
    public TextMeshProUGUI textUI;
    [TextArea(2, 10)]        // 💡 인스펙터에서 줄바꿈 가능하도록
    public string message;
    public float typingSpeed = 0.05f;

    [Header("Typing Sound")]
    public AudioSource audioSource;
    public float soundVolume = 1f;

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

            // 🔊 타이핑 사운드
            if (audioSource != null)
            {
                audioSource.volume = soundVolume;
                audioSource.Play();
            }

            yield return new WaitForSeconds(typingSpeed);
        }
    }
}
