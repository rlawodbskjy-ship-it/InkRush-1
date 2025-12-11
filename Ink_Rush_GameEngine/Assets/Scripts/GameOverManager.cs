using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameOverManager : MonoBehaviour
{
    public GameObject darkOverlay;
    public GameObject gameOverPanel;

    [Header("UI 사운드 관리자")]
    public UIAudioManager audioManager;   // 🔥 인스턴스로 호출할 변수

    [Header("사운드")]
    public AudioSource bgm;
    public AudioSource gameOverSfx;

    public static bool GameOver = false;

    public void ShowGameOver()
    {
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
        // 1) 시간 되돌리기
        Time.timeScale = 1f;

        // 2) UI 클릭 소리 재생 (인스턴스 변수로 호출!)
        if (audioManager != null)
            audioManager.PlayClickSound();

        // 3) 잠깐 기다렸다가 재시작
        yield return new WaitForSeconds(0.15f);

        // 4) 씬 다시 로드
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

        // 🔥 게임오버 플래그 초기화 → 다시 선 그릴 수 있음
        GameOverManager.GameOver = false;
    }
}
