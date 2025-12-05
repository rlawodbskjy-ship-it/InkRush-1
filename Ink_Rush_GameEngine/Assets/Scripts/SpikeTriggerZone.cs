using UnityEngine;

public class SpikeTriggerZone : MonoBehaviour
{
    public SpikeMove[] spikes;   // 여러 개도 가능하게 배열로

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("트리거에 뭔가 들어옴: " + other.name);

        if (!other.CompareTag("Player")) return;

        Debug.Log("플레이어가 트리거 존에 들어옴! 가시 발사!");

        foreach (var spike in spikes)
        {
            if (spike != null)
                spike.Activate();
        }

        // 한 번만 발동시키고 싶으면 주석 풀기
        // Destroy(gameObject);
    }
}
