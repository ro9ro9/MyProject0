using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealItem : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            var healer = other.GetComponent<PlayerHealItem>();
            if (healer != null)
            {
                if (healer.HasItem())
                {
                    UI_Game.instance.ShowMessage("이미 회복 아이템을 소지하고 있습니다.");
                }
                else
                {
                    healer.CollectItem();
                    Destroy(gameObject);
                }
            }
        }
    }
}
