using UnityEngine;

public class ObstacleTrigger : MonoBehaviour
{
    public Animator animator;
    public string triggerName = "Activate"; // Animator 파라미터 이름

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            animator.SetTrigger(triggerName);
        }
    }
}
