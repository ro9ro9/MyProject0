using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WeaponInfoUI : MonoBehaviour
{
    public Image weaponIcon;
    public TMP_Text weaponInfoText;
    public WeaponBase[] weapons;

    int currentIndex = 0;

    public void ShowWeapon(int direction)
    {
        currentIndex = (currentIndex + direction + weapons.Length) % weapons.Length;
        UpdateDisplay();
    }

    void UpdateDisplay()
    {
        var weapon = weapons[currentIndex];
        weaponIcon.sprite = weapon.weaponIcon;
        weaponInfoText.text = $"{weapon.name}\nDamage: {weapon.damage}\nAmmo: {weapon.maxAmmo}\nRate: {weapon.fireRate}";
    }

    void OnEnable()
    {
        UpdateDisplay();
    }
}
