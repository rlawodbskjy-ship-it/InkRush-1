using UnityEngine;

public class CircularMove : MonoBehaviour
{
    public float radius = 2f;
    public float speed = 2f;

    Vector3 center;   // ✅ 부모 기준 중심
    float angle;

    void Start()
    {
        center = transform.localPosition; // ✅ 핵심!
    }

    void Update()
    {
        angle += speed * Time.deltaTime;

        float x = center.x + Mathf.Cos(angle) * radius;
        float y = center.y + Mathf.Sin(angle) * radius;

        transform.localPosition = new Vector3(x, y, transform.localPosition.z);
    }
}
