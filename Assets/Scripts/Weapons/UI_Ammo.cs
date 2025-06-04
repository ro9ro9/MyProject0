using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UI_Ammo : MonoBehaviour
{
    public static UI_Ammo instance;

    public TextMeshProUGUI ammoText;
    public TextMeshProUGUI reloadHintText;
    public Image weaponImage;

    void Awake() => instance = this;

    public void UpdateAmmo(int current, int max)
    {
        ammoText.text = $"{current} / {max}";
    }

    public void SetWeaponIcon(Sprite icon)
    {
        weaponImage.sprite = icon;
    }
    public void ShowReloadHint(string message = "R키를 눌러 재장전하세요!")
    {
        reloadHintText.text = message;
        reloadHintText.enabled = true;
    }

    public void HideReloadHint()
    {
        reloadHintText.enabled = false;
    }

}
