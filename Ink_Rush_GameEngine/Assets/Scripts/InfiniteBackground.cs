using UnityEngine;

public class InfiniteBackground : MonoBehaviour
{
    public float speed = 2f;
    private float width;
    private Vector3 startPos;

    void Start()
    {
        startPos = transform.position;
        width = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    void Update()
    {
        transform.Translate(Vector3.left * speed * Time.deltaTime);

        // 일정 거리 이동하면 오른쪽으로 텔레포트
        if (transform.position.x <= startPos.x - width)
        {
            transform.position = new Vector3(startPos.x + width, startPos.y, startPos.z);
        }
    }
}
