using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealItem : MonoBehaviour
{
    bool hasItem = false;

    void Update()
    {
        if (hasItem && Input.GetKeyDown(KeyCode.I))
        {
            if (GetComponent<PlayerHealth>().currentHP < GetComponent<PlayerHealth>().maxHP)
            {
                GetComponent<PlayerHealth>().Heal(1);
                hasItem = false;
                UI_HealItem.instance.UpdateIcon(false);
            }
        }
    }

    public void CollectItem()
    {
        hasItem = true;
        UI_HealItem.instance.UpdateIcon(true);
    }

    public bool HasItem() => hasItem;
}
