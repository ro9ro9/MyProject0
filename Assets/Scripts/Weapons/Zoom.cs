using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zoom : MonoBehaviour
{
    public Camera playerCam;
    public float zoomFOV = 30f;
    private float defaultFOV;

    void Start()
    {
        defaultFOV = playerCam.fieldOfView;
    }

    void Update()
    {
        if (WeaponManager.currentWeapon != null && WeaponManager.currentWeapon.isSniper)
        {
            if (Input.GetMouseButton(1))
                playerCam.fieldOfView = zoomFOV;
            else
                playerCam.fieldOfView = defaultFOV;
        }
    }
}
