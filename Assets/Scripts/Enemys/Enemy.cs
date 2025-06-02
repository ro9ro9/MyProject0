using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float EnemyHP = 1f;

    public void TakeDamage(float damage)
    {
        EnemyHP -= damage;
        if (EnemyHP <= 0f)
        {
            Die();
        }
    }

    private void Die()
    {
        // Àû »ç¸Á Ã³¸® (¿¹: ÆÄ±«)
        Destroy(gameObject);
    }
}
