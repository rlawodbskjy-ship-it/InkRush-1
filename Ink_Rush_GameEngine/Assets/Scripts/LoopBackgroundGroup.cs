using UnityEngine;

public class LoopBackgroundGroup : MonoBehaviour
{
    public float speed = 2f;
    public Transform other;

    private float groupWidth;

    void Start()
    {
        // 자식들의 스프라이트 총 길이 계산
        float minX = float.MaxValue;
        float maxX = float.MinValue;

        SpriteRenderer[] renderers = GetComponentsInChildren<SpriteRenderer>();

        foreach (var r in renderers)
        {
            float left = r.bounds.min.x;
            float right = r.bounds.max.x;

            if (left < minX) minX = left;
            if (right > maxX) maxX = right;
        }

        groupWidth = maxX - minX;
    }

    void Update()
    {
        transform.Translate(Vector3.left * speed * Time.deltaTime);

        if (transform.position.x <= other.position.x - groupWidth)
        {
            transform.position = other.position + Vector3.right * groupWidth;
        }
    }
}
