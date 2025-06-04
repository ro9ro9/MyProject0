using UnityEngine;

public class GunFire : MonoBehaviour
{
    float lastFireTime;

    void Update()
    {
        if (Input.GetButton("Fire1") && Time.time - lastFireTime >= WeaponManager.currentWeapon.fireRate)
        {
            if (WeaponManager.instance.Fire())
            {
                Shoot();
                lastFireTime = Time.time;
            }
        }
    }

    void Shoot()
    {
        var weapon = WeaponManager.currentWeapon;

        GameObject bullet = Instantiate(
            weapon.bulletPrefab,
            WeaponManager.instance.firePoint.position,
            WeaponManager.instance.firePoint.rotation
        );

        bullet.GetComponent<Bullet>().Setup(
            weapon.damage,
            weapon.range,
            weapon.isLauncher,
            weapon.explosionRadius,
            weapon.isPenetrate
        );
    }
}
