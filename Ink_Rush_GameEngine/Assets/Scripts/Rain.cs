using UnityEngine;

public class Rain : MonoBehaviour
{
    public GameObject splashPrefab;
    public Transform mapParent;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!collision.gameObject.CompareTag("Ground")) return;

        // ✅ 정확히 닿은 지점
        Vector3 hitPos = collision.contacts[0].point;

        // ✅ 살짝 위로 보정 (감성 조절)
        hitPos.y += 0.02f; // 0.01~0.05 사이 취향

        GameObject splash = Instantiate(
            splashPrefab,
            hitPos,
            Quaternion.identity
        );

        splash.transform.SetParent(mapParent, true);

        Destroy(gameObject);
    }

}



