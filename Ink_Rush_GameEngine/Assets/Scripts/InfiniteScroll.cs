using UnityEngine;

public class InfiniteScroll : MonoBehaviour
{
    public float speed = 2f;           // 움직이는 속도
    public float resetPosition = 38f;  // 오른쪽 끝 위치 (씬 크기에 맞게 조절)
    public float startPosition = -38f; // 왼쪽 끝 위치 (씬 크기에 맞게 조절)

    void Update()
    {
        // 왼쪽으로 이동
        transform.Translate(Vector3.left * speed * Time.deltaTime);

        // 화면 밖으로 나가면 반대편으로 이동시키기
        if (transform.position.x <= startPosition)
        {
            transform.position = new Vector3(resetPosition, transform.position.y, transform.position.z);
        }
    }
}
