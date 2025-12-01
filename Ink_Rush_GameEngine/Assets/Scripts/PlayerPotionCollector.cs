using UnityEngine;

public class PlayerPotionCollector : MonoBehaviour
{
    public DrawLine2D drawLine;   // 게이지를 관리하는 스크립트
    public float recoverAmount = 0.25f;  // 한 번 먹을 때 회복량

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Potion"))
        {
            drawLine.RecoverGauge(recoverAmount);
            Destroy(other.gameObject);
        }
    }
}
