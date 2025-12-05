using UnityEngine;

public class PlayerHit : MonoBehaviour
{
    public GameOverManager gm;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Obstacle"))
        {
            gm.ShowGameOver();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Obstacle"))
        {
            gm.ShowGameOver();
        }
    }
}
