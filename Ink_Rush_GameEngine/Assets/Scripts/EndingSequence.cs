using UnityEngine;

public class EndingSequence : MonoBehaviour
{
    public TypingText typingText;

    public void PlayEnding()
    {
        typingText.StartTyping();
    }
}
