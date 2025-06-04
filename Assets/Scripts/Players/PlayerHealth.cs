using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHP = 3;
    public int currentHP;

    public float invincibleTime = 1f;   // 무적 시간 (초)
    float lastHitTime = -999f;          // 마지막으로 피해를 입은 시간

    void Start()
    {
        currentHP = maxHP;
        UI_Health.instance.UpdateHearts(currentHP);
    }

    public void TakeDamage(int amount)
    {
        // 무적 시간 체크
        if (Time.time - lastHitTime < invincibleTime)
            return;

        lastHitTime = Time.time;

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
