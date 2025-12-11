using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class FadeController : MonoBehaviour
{
    public Image fadeImage;
    public float fadeDuration = 1f;

    // 🔥 모든 씬에서 공유되는 플래그
    private static bool firstScenePassed = false;
    public static FadeController Instance;

    void Awake()
    {
        if (Instance == null)
            Instance = this;
    }

    void Start()
    {
        // 혹시 안 넣었으면 찾아보기 (선택사항)
        if (fadeImage == null)
            fadeImage = GetComponentInChildren<Image>();

        if (!firstScenePassed)
        {
            // ★ 게임 시작 첫 씬: 그냥 바로 보이게 (페이드인 X)
            SetAlpha(0f);
            firstScenePassed = true;
        }
        else
        {
            // ★ 그 다음부터 로드되는 모든 씬: 검은 화면에서 페이드인
            SetAlpha(1f);              // 먼저 까맣게
            StartCoroutine(FadeIn());  // 그 다음 서서히 투명
        }
    }

    // 버튼에서 호출할 함수
    public void FadeToScene(string sceneName)
    {
        StartCoroutine(FadeOutAndLoad(sceneName));
    }

    IEnumerator FadeOutAndLoad(string sceneName)
    {
        yield return StartCoroutine(FadeOut());
        SceneManager.LoadScene(sceneName);
    }

    IEnumerator FadeOut()
    {
        float t = 0f;
        while (t < fadeDuration)
        {
            t += Time.unscaledDeltaTime;

            SetAlpha(Mathf.Lerp(0f, 1f, t / fadeDuration));
            yield return null;
        }
        SetAlpha(1f);
    }

    IEnumerator FadeIn()
    {
        float t = 0f;
        while (t < fadeDuration)
        {
            t += Time.unscaledDeltaTime;

            SetAlpha(Mathf.Lerp(1f, 0f, t / fadeDuration));
            yield return null;
        }
        SetAlpha(0f);
    }

    void SetAlpha(float a)
    {
        if (fadeImage == null) return;
        Color c = fadeImage.color;
        c.a = a;
        fadeImage.color = c;
    }
}
