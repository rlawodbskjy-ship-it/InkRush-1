using UnityEngine;

public class BackgroundMove : MonoBehaviour
{
    public float speed = 2.5f;
    public bool isMoving = true;   // ✅ 이 줄 추가

    void Update()
    {
        if (!isMoving) return;

        transform.Translate(Vector3.left * speed * Time.deltaTime);
    }
}

