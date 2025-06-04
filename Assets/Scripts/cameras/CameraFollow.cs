using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;          // 플레이어
    public Vector3 offset = new Vector3(0, 3, -5);
    public float rotationSpeed = 3f;

    float yaw = 0f;
    float pitch = 15f;

    void LateUpdate()
    {
        yaw += Input.GetAxis("Mouse X") * rotationSpeed;
        pitch -= Input.GetAxis("Mouse Y") * rotationSpeed;
        pitch = Mathf.Clamp(pitch, -80f, 80f);  // 위아래 제한

        Quaternion rotation = Quaternion.Euler(pitch, yaw, 0f);
        transform.position = target.position + rotation * offset;
        transform.LookAt(target);
    }

    public Vector3 GetLookDirection()
    {
        Vector3 forward = transform.forward;
        forward.y = 0;
        return forward.normalized;
    }
}
