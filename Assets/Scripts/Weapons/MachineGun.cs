using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MachineGun : WeaponBase
{
    public float fireRate = 0.1f; // 연사 속도 (초 단위, 0.1초마다 발사)
    private float nextFireTime = 0f;

    private void Start()
    {
        maxAmmo = 100;
        damage = 2f;
        range = 5f;
        reloadTime = 5f;
        currentAmmo = maxAmmo;
    }

    public override void Fire()
    {
        if (isReloading) return;

        if (Time.time < nextFireTime) return;

        if (currentAmmo <= 0)
        {
            UIManager.Instance.ShowReloadMessage();
            return;
        }

        currentAmmo--;
        nextFireTime = Time.time + fireRate;

        // 일반 Raycast 타격 처리
        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out RaycastHit hit, range))
        {
            var enemy = hit.collider.GetComponent<Enemy>();
            if (enemy != null)
            {
                enemy.TakeDamage(damage);
            }
        }
    }
}
