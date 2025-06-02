using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Launcher : WeaponBase
{
    public float explosionRadius = 3f;

    private void Start()
    {
        maxAmmo = 1;
        damage = 10f;
        range = 5f;
        reloadTime = 3f;
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
        // 발사체 인스턴스 생성 후, OnHit에서 범위 데미지 처리
    }

    public void Explode(Vector3 position)
    {
        Collider[] hitColliders = Physics.OverlapSphere(position, explosionRadius);
        foreach (var col in hitColliders)
        {
            var enemy = col.GetComponent<Enemy>();
            if (enemy != null)
                enemy.TakeDamage(damage);
        }
    }
}
