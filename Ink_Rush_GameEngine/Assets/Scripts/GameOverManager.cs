using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    public GameObject darkOverlay;
    public GameObject gameOverPanel;

    public void ShowGameOver()
    {
        darkOverlay.SetActive(true);
        gameOverPanel.SetActive(true);

        Time.timeScale = 0f; // 🔥 게임 정지
    }

    public void RestartGame()
    {
        Time.timeScale = 1f; // 시간 되돌리기
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
