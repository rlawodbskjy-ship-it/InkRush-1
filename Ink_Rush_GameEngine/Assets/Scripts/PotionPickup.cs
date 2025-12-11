using UnityEngine;

public class PotionPickup : MonoBehaviour
{
    public AudioSource audioSource;   // 🔊 포션 사운드
    public float destroyDelay = 0.2f; // 사운드 재생 후 제거 시간

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            audioSource.Play();     // 🔊 사운드 재생
            Destroy(gameObject, destroyDelay); // 🔥 포션 사라짐 (사운드는 남기고)
        }
    }
}
