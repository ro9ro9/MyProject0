using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_HealItem : MonoBehaviour
{
    public static UI_HealItem instance;

    public Image icon;
    public Sprite healItemSprite;
    public Sprite emptySprite;

    void Awake() => instance = this;

    public void UpdateIcon(bool hasItem)
    {
        icon.sprite = hasItem ? healItemSprite : emptySprite;
    }
}
