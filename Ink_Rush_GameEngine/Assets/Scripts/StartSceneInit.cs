using UnityEngine;

public class StartSceneInit : MonoBehaviour
{
    void Awake()
    {
        Time.timeScale = 1f;   // ✅ 무조건 복구
    }
}
