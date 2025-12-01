using UnityEngine;

public class InfoToggle : MonoBehaviour
{
    public CanvasGroup mainUIGroup;  // InkRush + 레벨버튼 + InfoButton
    public GameObject infoPanel;     // 설명서 패널

    bool isOpen = false;

    public void ToggleInfo()
    {
        isOpen = !isOpen;

        // 설명서 보이기/숨기기
        infoPanel.SetActive(isOpen);

        // 메인 UI 페이드 (완전 숨김/표시)
        mainUIGroup.alpha = isOpen ? 0f : 1f;
        mainUIGroup.interactable = !isOpen;
        mainUIGroup.blocksRaycasts = !isOpen;
    }
}
