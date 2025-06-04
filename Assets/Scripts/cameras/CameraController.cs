using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform playerBody;
    public Transform cameraPivot;

    [Header("마우스 감도 및 회전")]
    public float mouseSensitivity = 100f;
    public float rotationSpeed = 10f; // 플레이어가 카메라 방향으로 도는 속도
    public bool lockView = false;

    float xRotation = 0f;

    void Update()
    {
        if (lockView) return;

        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, 0f, 80f); // 상하 시야 제한

        cameraPivot.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        playerBody.Rotate(Vector3.up * mouseX, Space.Self);
    }
}
