using UnityEngine;

public class HomeButton : MonoBehaviour
{
   public void GoHome()
    {
        Time.timeScale = 1f;               // 게임 정지 상태 해제
        FadeController.Instance.FadeToScene("startscene");
    }

}
