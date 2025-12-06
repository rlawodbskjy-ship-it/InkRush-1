using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameOverFadeOut : MonoBehaviour
{
    public CanvasGroup gameOverGroup;
    public float fadeDuration = 0.8f;
    public string targetScene = "startscene";

    public void OnClickHome()
    {
        StartCoroutine(FadeOutAndGoHome());
    }

    IEnumerator FadeOutAndGoHome()
    {
        // ✅ 클릭 막기
        gameOverGroup.interactable = false;
        gameOverGroup.blocksRaycasts = false;

        float t = 0f;
        float startAlpha = gameOverGroup.alpha;

        while (t < fadeDuration)
        {
            t += Time.unscaledDeltaTime;   // 게임 멈춘 상태에서도 작동
            gameOverGroup.alpha = Mathf.Lerp(startAlpha, 0f, t / fadeDuration);
            yield return null;
        }

        gameOverGroup.alpha = 0f;

        SceneManager.LoadScene(targetScene);
    }
}
