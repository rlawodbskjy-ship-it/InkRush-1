using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;   // 플레이어
    public float smoothSpeed = 5f;
    public Vector3 offset;

    void LateUpdate()
    {
        Vector3 pos = transform.position;
        pos.x = target.position.x + offset.x;
        transform.position = pos;
    }

}
