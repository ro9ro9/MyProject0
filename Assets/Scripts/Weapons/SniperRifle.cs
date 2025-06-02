using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SniperRifle : WeaponBase
{
    public bool isZoomed = false;

    private void Start()
    {
        maxAmmo = 10;
        damage = 15f;
        range = 10f;
        reloadTime = 3.5f;
        currentAmmo = maxAmmo;
    }

    public override void Fire()
    {
        if (isReloading) return;
        if (currentAmmo <= 0)
        {
            UIManager.Instance.ShowReloadMessage();
            return;
        }

        currentAmmo--;

        // RaycastAll로 관통 구현
        RaycastHit[] hits = Physics.RaycastAll(Camera.main.transform.position, Camera.main.transform.forward, range);
        foreach (var hit in hits)
        {
            var enemy = hit.collider.GetComponent<Enemy>();
            if (enemy != null)
                enemy.TakeDamage(damage);
        }
    }

    public void ToggleZoom()
    {
        isZoomed = !isZoomed;
        Camera.main.fieldOfView = isZoomed ? 30 : 60;
    }
}
