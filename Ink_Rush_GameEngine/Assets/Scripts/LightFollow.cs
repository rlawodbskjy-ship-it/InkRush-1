using UnityEngine;

public class LightFollow : MonoBehaviour
{
    public Transform target;   // 플레이어
    public Vector3 offset;

    void LateUpdate()
    {
        if (target == null) return;

        transform.position = target.position + offset;
    }
}
