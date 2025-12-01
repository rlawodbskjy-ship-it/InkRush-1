using UnityEngine;

public class BackgroundMove : MonoBehaviour
{
    public float speed = 2f;   // 이동 속도

    void Update()
    {
        transform.Translate(Vector3.left * speed * Time.deltaTime);
    }
}
