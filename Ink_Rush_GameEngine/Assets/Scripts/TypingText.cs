using TMPro;
using UnityEngine;
using System.Collections;

public class TypingText : MonoBehaviour
{
    public TextMeshProUGUI textUI;
    public string message;
    public float typingSpeed = 0.05f;

    Coroutine typingRoutine;

    void OnEnable()
    {
        StartTyping();
    }

    // ✅ 외부에서 호출 가능한 함수
    public void StartTyping()
    {
        if (typingRoutine != null)
            StopCoroutine(typingRoutine);

        typingRoutine = StartCoroutine(Play());
    }

    // ❌ 외부 접근 막고
    IEnumerator Play()
    {
        textUI.text = "";

        foreach (char c in message)
        {
            textUI.text += c;
            yield return new WaitForSeconds(typingSpeed);
        }
    }
}
