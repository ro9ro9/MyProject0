using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class WeaponBase : MonoBehaviour
{
    public int maxAmmo;
    public float damage;
    public float range;
    public float reloadTime;
    public int currentAmmo;
    public bool isReloading = false;
    private Coroutine reloadCoroutine;

    public abstract void Fire();
    public virtual void Reload()
    {
        if (!isReloading)
            StartCoroutine(ReloadRoutine());
    }
    public virtual void CancelReload()
    {
        if (isReloading && reloadCoroutine != null)
        {
            StopCoroutine(reloadCoroutine);
            isReloading = false;
            PlayerMovement.Instance.SetReloadSpeed(false); // 이동속도 복구
        }
    }

    protected virtual IEnumerator ReloadRoutine()
    {
        isReloading = true;
        PlayerMovement.Instance.SetReloadSpeed(true); // 이동속도 느려짐
        yield return new WaitForSeconds(reloadTime);
        currentAmmo = maxAmmo;
        isReloading = false;
        PlayerMovement.Instance.SetReloadSpeed(false); // 원래 속도 복구
    }
}
