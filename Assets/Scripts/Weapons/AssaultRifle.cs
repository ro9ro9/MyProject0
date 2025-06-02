using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssaultRifle : WeaponBase
{
    private void Start()
    {
        maxAmmo = 40;
        damage = 3f;
        range = 5f;
        reloadTime = 2f;
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
        // 피격 처리
    }
}
