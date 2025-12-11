using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class DrawLine2D : MonoBehaviour
{
    private LineRenderer lineRenderer;
    private EdgeCollider2D edgeCollider;
    private Rigidbody2D rb;

    [Header("게이지 설정")]
    public Slider drawGauge;
    public float maxGauge = 1f;
    public float useSpeed = 0.3f;
    public float regenSpeed = 0.2f;

    [Header("화면 이동 보정")]
    public float worldMoveSpeed = 5f;

    private float currentGauge;

    private List<Vector2> worldPoints = new();
    private List<Vector2> localPoints = new();
    private bool isDrawing;

    [Header("사운드 설정")]
    public AudioClip drawSound;
    private AudioSource audioSource;


    public void RecoverGauge(float amount)
    {
        currentGauge += amount;
        currentGauge = Mathf.Clamp(currentGauge, 0, maxGauge);
        drawGauge.value = currentGauge;
    }

    void Awake()
    {
        TryGetComponent(out lineRenderer);
        TryGetComponent(out edgeCollider);
        TryGetComponent(out rb);

        // 오디오 설정
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.loop = true;
        audioSource.playOnAwake = false;
        audioSource.volume = 0.6f;

        rb.bodyType = RigidbodyType2D.Static;

        lineRenderer.useWorldSpace = true;
        lineRenderer.startWidth = 0.12f;
        lineRenderer.endWidth = 0.12f;
        lineRenderer.material = new Material(Shader.Find("Sprites/Default"));
        lineRenderer.positionCount = 0;

        edgeCollider.isTrigger = false;

        currentGauge = maxGauge;
        drawGauge.maxValue = maxGauge;
        drawGauge.value = currentGauge;
    }

    void Update()
    {
        // 🛑 미션 클리어 or 게임오버 → 그리기 금지
        if (GoalTrigger.MissionCleared || GameOverManager.GameOver)
        {
            if (audioSource.isPlaying)
                audioSource.Stop();
            return;
        }

        MoveLineWithWorld();

        // 게이지 없으면 종료
        if (currentGauge <= 0f)
        {
            if (audioSource.isPlaying)
                audioSource.Stop();
            return;
        }

        if (Input.GetMouseButtonDown(0))
        {
            isDrawing = true;

            if (drawSound != null)
            {
                audioSource.clip = drawSound;
                audioSource.Play();
            }

            worldPoints.Clear();
            localPoints.Clear();
            lineRenderer.positionCount = 0;
        }

        if (Input.GetMouseButton(0) && isDrawing)
        {
            currentGauge -= useSpeed * Time.deltaTime;
            currentGauge = Mathf.Clamp(currentGauge, 0, maxGauge);
            drawGauge.value = currentGauge;

            if (currentGauge <= 0)
            {
                audioSource.Stop();
                isDrawing = false;
                return;
            }

            // -------------------------
            // 🎯 펜 끝 위치 사용 (EndPoint)
            // -------------------------
            Vector3 wp3;

            if (EndPoint.Instance != null)
            {
                wp3 = EndPoint.Instance.GetWorldPosition();
            }
            else
            {
                wp3 = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            }

            wp3.z = 0f;
            Vector2 worldPos = wp3;

            if (worldPoints.Count == 0 || 
                Vector2.Distance(worldPoints[^1], worldPos) > 0.1f)
            {
                worldPoints.Add(worldPos);
                lineRenderer.positionCount = worldPoints.Count;
                lineRenderer.SetPosition(worldPoints.Count - 1, worldPos);

                Vector2 localPos = transform.InverseTransformPoint(worldPos);
                localPoints.Add(localPos);

                if (localPoints.Count > 1)
                    edgeCollider.SetPoints(localPoints);
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            isDrawing = false;
            audioSource.Stop();
        }
    }

    void MoveLineWithWorld()
    {
        if (lineRenderer.positionCount == 0)
            return;

        Vector3 move = Vector3.left * worldMoveSpeed * Time.deltaTime;

        for (int i = 0; i < lineRenderer.positionCount; i++)
        {
            Vector3 p = lineRenderer.GetPosition(i);
            p += move;
            lineRenderer.SetPosition(i, p);
            worldPoints[i] = p;
        }

        localPoints.Clear();
        for (int i = 0; i < worldPoints.Count; i++)
        {
            Vector2 local = transform.InverseTransformPoint(worldPoints[i]);
            localPoints.Add(local);
        }

        edgeCollider.SetPoints(localPoints);
    }
}
