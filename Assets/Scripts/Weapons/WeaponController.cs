using System.Collections;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    public WeaponBase[] weapons; // 인스펙터에 0=돌소, 1=저격, 2=머신건, 3=런처
    private int currentWeaponIndex = 0;
    public WeaponBase currentWeapon;

    void Start()
    {
        EquipWeapon(0); // 처음에 돌격소총 장착
    }

    void Update()
    {
        if (Input.GetMouseButton(0))
            currentWeapon.Fire();

        if (Input.GetKeyDown(KeyCode.R))
            currentWeapon.Reload();

        if (Input.GetMouseButtonDown(1) && currentWeapon is SniperRifle sniper)
            sniper.ToggleZoom();

        if (Input.GetKeyDown(KeyCode.Alpha1)) EquipWeapon(0);
        if (Input.GetKeyDown(KeyCode.Alpha2)) EquipWeapon(1);
        if (Input.GetKeyDown(KeyCode.Alpha3)) EquipWeapon(2);
        if (Input.GetKeyDown(KeyCode.Alpha4)) EquipWeapon(3);
    }
    void EquipWeapon(int index)
    {
        if (index == currentWeaponIndex || index < 0 || index >= weapons.Length)
            return;

        // 기존 무기의 재장전 취소
        weapons[currentWeaponIndex].CancelReload();

        // 현재 무기 비활성화
        weapons[currentWeaponIndex].gameObject.SetActive(false);

        // 새로운 무기 장착
        currentWeaponIndex = index;
        currentWeapon = weapons[currentWeaponIndex];
        currentWeapon.gameObject.SetActive(true);
    }
}
