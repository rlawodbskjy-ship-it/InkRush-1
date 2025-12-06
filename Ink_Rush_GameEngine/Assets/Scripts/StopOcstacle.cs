using UnityEngine;

public class ObstacleStopByLine : MonoBehaviour
{
    Animator anim;

    void Awake()
    {
        anim = GetComponent<Animator>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // ✅ 내가 가진 "BoxCollider2D"가
        // ✅ 상대의 "EdgeCollider2D (선)"과 충돌했을 때만
        if (collision.otherCollider is BoxCollider2D &&
            collision.collider is EdgeCollider2D)
        {
            Debug.Log("박스콜리더가 선에 닿음 → 애니메이션 멈춤");
            anim.speed = 0f;
        }
    }
}
