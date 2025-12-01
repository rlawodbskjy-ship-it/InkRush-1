using UnityEngine;
using System.Collections;

public class MainUIFade : MonoBehaviour
{
    public CanvasGroup uiGroup;
    public float fadeTime = 0.3f;

    public void FadeOut()
    {
        StartCoroutine(Fade(1f, 0f));
    }

    IEnumerator Fade(float from, float to)
    {
        float t = 0f;
        uiGroup.interactable = false;
        uiGroup.blocksRaycasts = false;

        while (t < fadeTime)
        {
            t += Time.deltaTime;
            uiGroup.alpha = Mathf.Lerp(from, to, t / fadeTime);
            yield return null;
        }

        uiGroup.alpha = to;
    }
}
