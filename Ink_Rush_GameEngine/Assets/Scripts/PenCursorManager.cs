using UnityEngine;

public class PenCursorManager : MonoBehaviour
{
    public GameObject penCursorUI;

    public GameObject missionClearPanel;
    public GameObject gameOverPanel;
    public GameObject endingPanel;

    void Update()
    {
        bool uiBlocking =
            missionClearPanel.activeSelf ||
            gameOverPanel.activeSelf ||
            endingPanel.activeSelf;

        // 펜 커서 UI는 UI 블로킹이 없을 때만 보임
        bool penVisible = !uiBlocking;

        penCursorUI.SetActive(penVisible);

        // 펜이 보일 때 시스템 커서를 숨김
        Cursor.visible = !penVisible;
    }
}
