using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealItemDrop : MonoBehaviour
{
    public GameObject healItemPrefab;
    public float dropChance = 0.001f;

    public void TakeDamage(float dmg)
    {
        Destroy(gameObject);
        KillCounter.instance.AddKill();

        if (Random.value < dropChance)
        {
            Instantiate(healItemPrefab, transform.position, Quaternion.identity);
        }
    }
}
