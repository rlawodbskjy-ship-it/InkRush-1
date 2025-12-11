using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameOverFadeOut : MonoBehaviour
{
    public CanvasGroup gameOverGroup;   // 🔥 이제 GameOverGroup을 연결!
    public float fadeDuration = 0.8f;
    public string targetScene = "startscene";

    [Header("사운드")]
    public AudioSource bgm;
    public AudioSource gameOverBgm;

    bool gameOverSoundPlayed = false;

    private void OnEnable()
    {
        // 게임오버 음악은 1번만 재생
        if (!gameOverSoundPlayed && gameOverBgm != null)
        {
            if (bgm != null) bgm.Stop();
            gameOverBgm.Play();
            gameOverSoundPlayed = true;
        }
    }

    public void OnClickHome()
    {
        StartCoroutine(FadeOutAndGoHome());
    }

    IEnumerator FadeOutAndGoHome()
    {
        // 클릭 막기
        gameOverGroup.interactable = false;
        gameOverGroup.blocksRaycasts = false;

        float t = 0f;
        float startAlpha = gameOverGroup.alpha;

        while (t < fadeDuration)
        {
            t += Time.unscaledDeltaTime;
            float a = Mathf.Lerp(startAlpha, 0f, t / fadeDuration);
            gameOverGroup.alpha = a;
            yield return null;
        }

        gameOverGroup.alpha = 0f;

        SceneManager.LoadScene(targetScene);
    }
}
