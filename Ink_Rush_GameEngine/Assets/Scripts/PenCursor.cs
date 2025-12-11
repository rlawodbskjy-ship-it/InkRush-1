using UnityEngine;
using UnityEngine.UI;

public class PenCursor : MonoBehaviour
{
    public RectTransform penImage;

    void Update()
    {
        Vector2 pos;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(
            transform as RectTransform,
            Input.mousePosition,
            null,
            out pos);

        penImage.anchoredPosition = pos;
    }
}
