using UnityEngine;

public class InfoToggle : MonoBehaviour
{
    public GameObject infoPanel; // 설명 이미지 오브젝트

    public void ToggleInfo()
    {
        infoPanel.SetActive(!infoPanel.activeSelf);
    }
}
