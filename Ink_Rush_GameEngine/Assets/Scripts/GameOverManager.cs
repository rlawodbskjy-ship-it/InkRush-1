using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameOverManager : MonoBehaviour
{
    public GameObject darkOverlay;
    public GameObject gameOverPanel;

    [Header("UI 사운드 관리자")]
    public UIAudioManager audioManager;

    [Header("사운드")]
    public AudioSource bgm;
    public AudioSource gameOverSfx;

    public static bool GameOver = false;

    void Awake()
    {
        // ✅ 씬 시작 시 무조건 초기화
        GameOver = false;
    }

    public void ShowGameOver()
    {
        if (GameOver) return; // 중복 방지
        GameOver = true;

        if (bgm != null)
            bgm.Stop();

        if (gameOverSfx != null)
            gameOverSfx.Play();

        darkOverlay.SetActive(true);
        gameOverPanel.SetActive(true);

        Time.timeScale = 0f;
    }

    public void RestartGame()
    {
        StartCoroutine(RestartFlow());
    }

    IEnumerator RestartFlow()
    {
        Time.timeScale = 1f;

        if (audioManager != null)
            audioManager.PlayClickSound();

        yield return new WaitForSeconds(0.15f);

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        // ❌ 여기서 GameOver false 하면 안 됨
    }
}
