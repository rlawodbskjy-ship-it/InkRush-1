using UnityEngine;

public class GameStateReset : MonoBehaviour
{
    void Awake()
    {
        // 🔄 씬 들어올 때 상태 초기화
        GameOverManager.GameOver = false;
        GoalTrigger.MissionCleared = false;
    }
}
