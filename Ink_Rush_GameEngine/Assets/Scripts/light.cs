using UnityEngine;
using System.Collections;

public class LightBlink : MonoBehaviour
{
    public Sprite spriteA;
    public Sprite spriteB;

    public float interval = 0.5f; // 몇 초마다 바뀔지

    private SpriteRenderer sr;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        StartCoroutine(Blink());
    }

    IEnumerator Blink()
    {
        while (true)
        {
            sr.sprite = spriteA;
            yield return new WaitForSeconds(interval);

            sr.sprite = spriteB;
            yield return new WaitForSeconds(interval);
        }
    }
}
