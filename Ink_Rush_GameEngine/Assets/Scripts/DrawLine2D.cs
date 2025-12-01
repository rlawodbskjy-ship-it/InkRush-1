using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class DrawLine2D : MonoBehaviour
{
    private LineRenderer lineRenderer;
    private EdgeCollider2D edgeCollider;
    private Rigidbody2D rb;

    [Header("게이지 설정")]
    public Slider drawGauge;      // UI Slider 연결
    public float maxGauge = 1f;
    public float useSpeed = 0.3f; // 그릴 때 감소 속도
    public float regenSpeed = 0.2f; // 회복 속도

    private float currentGauge;

    private List<Vector2> worldPoints = new();
    private List<Vector2> localPoints = new();
    private bool isDrawing;

    void Awake()
    {
        if (!TryGetComponent(out lineRenderer))
            lineRenderer = gameObject.AddComponent<LineRenderer>();

        if (!TryGetComponent(out edgeCollider))
            edgeCollider = gameObject.AddComponent<EdgeCollider2D>();

        if (!TryGetComponent(out rb))
            rb = gameObject.AddComponent<Rigidbody2D>();

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
    

        // ✅ 게이지 0이면 그리기 불가
        if (currentGauge <= 0f)
            return;

        if (Input.GetMouseButtonDown(0))
        {
            isDrawing = true;
            worldPoints.Clear();
            localPoints.Clear();
            lineRenderer.positionCount = 0;
        }

        if (Input.GetMouseButton(0) && isDrawing)
        {
            // ✅ 게이지 소모
            currentGauge -= useSpeed * Time.deltaTime;
            currentGauge = Mathf.Clamp(currentGauge, 0, maxGauge);
            drawGauge.value = currentGauge;

            if (currentGauge <= 0f)
            {
                isDrawing = false;
                return;
            }

            Vector3 wp3 = Camera.main.ScreenToWorldPoint(Input.mousePosition);
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
        }
    }
}
