using UnityEngine;

public class HomeButton : MonoBehaviour
{
    public GameOverFadeOut fadeOut;

    public void GoHome()
    {
        // 🔥 GameOverFadeOut의 페이드 + 씬로드 실행
        fadeOut.OnClickHome();
    }
}
