using UnityEngine;

public class SpikeMove : MonoBehaviour
{
    public float speed = 5f;
    public Vector2 direction = Vector2.left;   // 왼쪽으로 날아가게

    private bool activated = false;

    void Update()
    {
        if (!activated) return;

        // 방향 * 속도 * 시간만큼 이동
        transform.Translate(direction.normalized * speed * Time.deltaTime);
    }

    // 트리거에서 이 함수를 호출해줌
    public void Activate()
    {
        if (activated) return;

        activated = true;
        Debug.Log($"Spike 활성화됨: {name}");
    }
}
