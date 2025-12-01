using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonScaleEffect : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Vector3 normalScale = Vector3.one;        // 기본 크기
    public Vector3 hoverScale = new Vector3(1.1f, 1.1f, 1f); // 커지는 크기
    public float speed = 10f;

    private bool isHovered = false;

    void Update()
    {
        if (isHovered)
            transform.localScale = Vector3.Lerp(transform.localScale, hoverScale, Time.deltaTime * speed);
        else
            transform.localScale = Vector3.Lerp(transform.localScale, normalScale, Time.deltaTime * speed);
    }
    
    public void OnPointerEnter(PointerEventData eventData)
    {
        isHovered = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        isHovered = false;
    }
}
