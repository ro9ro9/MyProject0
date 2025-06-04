using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDirection : MonoBehaviour
{
    public CameraFollow camFollow;

    void Update()
    {
        if (Input.GetMouseButton(1)) // ¿ìÅ¬¸¯
        {
            Vector3 lookDir = camFollow.GetLookDirection();
            if (lookDir != Vector3.zero)
            {
                Quaternion targetRot = Quaternion.LookRotation(lookDir);
                transform.rotation = Quaternion.Slerp(transform.rotation, targetRot, Time.deltaTime * 10f);
            }
        }
    }
}
