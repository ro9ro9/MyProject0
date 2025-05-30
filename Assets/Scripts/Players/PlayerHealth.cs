using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHP = 3;
    public int currentHP;

    void Start()
    {
        currentHP = maxHP;
        UI_Health.instance.UpdateHearts(currentHP);
    }

    public void TakeDamage(int amount)
    {
        currentHP -= amount;
        currentHP = Mathf.Clamp(currentHP, 0, maxHP);
        UI_Health.instance.UpdateHearts(currentHP);

        if (currentHP <= 0)
        {
            Debug.Log("Game Over");
        }
    }

    public void Heal(int amount)
    {
        currentHP += amount;
        currentHP = Mathf.Clamp(currentHP, 0, maxHP);
        UI_Health.instance.UpdateHearts(currentHP);
    }
}
