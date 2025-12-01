using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMove2D : MonoBehaviour
{
    public float moveSpeed = 5f;

    Rigidbody2D rb;
    Animator anim;
    SpriteRenderer sr;

    float h;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        // ✅ A, D 입력 받기
        h = Input.GetAxisRaw("Horizontal");

        // ✅ 애니메이션 전환
        anim.SetBool("isRun", h != 0);

        // ✅ 방향 전환
        if (h > 0)
            sr.flipX = false;
        else if (h < 0)
            sr.flipX = true;
    }

    void FixedUpdate()
    {
        // ✅ 물리 이동
        rb.velocity = new Vector2(h * moveSpeed, rb.velocity.y);
    }
}
