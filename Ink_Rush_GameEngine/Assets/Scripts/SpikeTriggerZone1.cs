using UnityEngine;

public class SpikeTriggerZone : MonoBehaviour
{
    public Animator spikeAnimator;
    private bool activated = false;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (activated) return;

        if (other.CompareTag("Player"))
        {
            Debug.Log("✅ 플레이어 진입, 가시 작동");
            spikeAnimator.SetTrigger("Activate");
            activated = true;
        }
    }
}
