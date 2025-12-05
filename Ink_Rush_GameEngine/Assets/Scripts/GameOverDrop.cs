using UnityEngine;

public class GameOverDrop : MonoBehaviour
{
    RectTransform rt;

    [Header("Drop Settings")]
    public float startOffset = 800f;
    public float targetY = 0f;
    public float dropDuration = 0.35f;

    [Header("Bounce Settings")]
    public float bounceHeight = 120f;   // 🔥 튀는 높이 두 배 증가!
    public int bounceCount = 4;
    public float bounceDamping = 0.55f;

    float timer = 0f;
    bool isDropping = false;
    bool isBouncing = false;

    int currentBounce = 0;
    float bounceTime = 0f;
    float singleBounceDuration = 0.25f;

    void Awake()
    {
        rt = GetComponent<RectTransform>();
    }

    void OnEnable()
    {
        Vector2 pos = rt.anchoredPosition;
        pos.y = startOffset;
        rt.anchoredPosition = pos;

        timer = 0f;
        currentBounce = 0;

        isDropping = true;
        isBouncing = false;
    }

    void Update()
    {
        if (isDropping)
            DropMotion();
        else if (isBouncing)
            BounceMotion();
    }

    void DropMotion()
    {
        timer += Time.unscaledDeltaTime;
        float t = timer / dropDuration;

        // EaseOutCubic
        t = 1f - Mathf.Pow(1f - t, 3);

        float newY = Mathf.Lerp(startOffset, targetY, t);

        Vector2 pos = rt.anchoredPosition;
        pos.y = newY;
        rt.anchoredPosition = pos;

        if (t >= 1f)
        {
            timer = 0f;
            isDropping = false;
            StartBounce();
        }
    }

    void StartBounce()
    {
        isBouncing = true;
        bounceTime = 0f;
    }

    void BounceMotion()
    {
        bounceTime += Time.unscaledDeltaTime;
        float t = bounceTime / singleBounceDuration;

        // 🔥 반대로 튀는 문제 해결 → 위로 튀게 만들기
        float bounce = Mathf.Sin(t * Mathf.PI) * bounceHeight;

        Vector2 pos = rt.anchoredPosition;
        pos.y = targetY + bounce;   // ← 튀는 방향 수정 완료!
        rt.anchoredPosition = pos;

        if (t >= 1f)
        {
            currentBounce++;

            if (currentBounce < bounceCount)
            {
                bounceHeight *= bounceDamping;
                bounceTime = 0f;
            }
            else
            {
                pos.y = targetY;
                rt.anchoredPosition = pos;
                isBouncing = false;
            }
        }
    }
}
