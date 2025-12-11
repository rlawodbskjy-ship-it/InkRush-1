using UnityEngine;

public class EndPoint : MonoBehaviour
{
    public static EndPoint Instance;

    RectTransform rect;

    void Awake()
    {
        Instance = this;
        rect = GetComponent<RectTransform>();
    }

    // 펜 끝의 월드 좌표 반환
    public Vector3 GetWorldPosition()
    {
        // Canvas가 Screen Space - Overlay 라는 가정
        Vector3 screenPos = rect.position;                  // UI 좌표
        Vector3 worldPos = Camera.main.ScreenToWorldPoint(screenPos);
        worldPos.z = 0f;
        return worldPos;
    }
}
