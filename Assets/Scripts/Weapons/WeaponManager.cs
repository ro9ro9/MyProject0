using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    GameObject equippedModel; // 현재 무기 모델
    public Transform weaponHolder; // 손에 장착할 위치

    public WeaponBase[] weapons;
    public Transform firePoint;
    public static WeaponManager instance;


    int currentIndex = 0;
    int currentAmmo;
    bool isReloading = false;
    float switchCooldown = 1f;
    float switchTimer = 0f;

    public static WeaponBase currentWeapon;

    void Start()
    {
        EquipWeapon(0);
    }

    void Update()
    {
        switchTimer -= Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.Alpha1)) TrySwitch(0);
        if (Input.GetKeyDown(KeyCode.Alpha2)) TrySwitch(1);
        if (Input.GetKeyDown(KeyCode.Alpha3)) TrySwitch(2);
        if (Input.GetKeyDown(KeyCode.Alpha4)) TrySwitch(3);

        if (Input.GetKeyDown(KeyCode.R)) StartCoroutine(Reload());

        UI_Ammo.instance.UpdateAmmo(currentAmmo, currentWeapon.maxAmmo);
    }
    void Awake() => instance = this;
    

    void TrySwitch(int index)
    {
        if (switchTimer <= 0 && index != currentIndex)
        {
            switchTimer = switchCooldown;
            EquipWeapon(index);
        }
    }

    void EquipWeapon(int index)
    {
        currentIndex = index;
        currentWeapon = weapons[index];
        currentAmmo = currentWeapon.maxAmmo;

        // UI 갱신
        UI_Ammo.instance.SetWeaponIcon(currentWeapon.weaponIcon);

        // 이전 무기 모델 제거
        if (equippedModel != null)
            Destroy(equippedModel);

        // 새 무기 모델 생성 및 장착
        if (currentWeapon.weaponPrefab != null && weaponHolder != null)
        {
            equippedModel = Instantiate(currentWeapon.weaponPrefab, weaponHolder);
            equippedModel.transform.localPosition = Vector3.zero;
            equippedModel.transform.localRotation = Quaternion.identity;

            // 무기 프리팹 내에 firePoint가 있다면, 참조 변경도 가능
            Transform newFirePoint = equippedModel.transform.Find("FirePoint");
            if (newFirePoint != null)
                firePoint = newFirePoint;
        }
    }

    public bool Fire()
    {
        if (isReloading) return false;

        if (currentAmmo <= 0)
        {
            UI_Ammo.instance.ShowReloadHint(); // 예: "R키를 눌러 재장전하세요!"
            return false;
        }

        currentAmmo--;
        return true;
    }

    IEnumerator Reload()
    {
        if (isReloading) yield break;
        isReloading = true;

        // 이동 속도 감소 적용 가능
        yield return new WaitForSeconds(currentWeapon.reloadTime);

        currentAmmo = currentWeapon.maxAmmo;
        isReloading = false;

        UI_Ammo.instance.HideReloadHint(); // 재장전 끝나면 안내 메시지 숨기기
    }

    public int GetCurrentAmmo() => currentAmmo;        
}
