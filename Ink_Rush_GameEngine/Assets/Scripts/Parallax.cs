using UnityEngine;

public class Parallax : MonoBehaviour
{
    public float speed = 0.1f;    // 속도 (오브젝트마다 다르게 설정)
    private Vector3 startPos;

    void Start()
    {
        startPos = transform.position;
    }

    void Update()
    {
        float move = Mathf.Repeat(Time.time * speed, 10f);
        transform.position = startPos + Vector3.left * move;
    }
}
