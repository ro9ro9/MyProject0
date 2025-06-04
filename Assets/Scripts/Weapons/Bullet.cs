using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    float damage;
    float range;
    float speed = 50f;
    bool isLauncher;
    bool isPenetrate;
    float explosionRadius;

    public void Setup(float damage, float range, bool isLauncher = false, float explosionRadius = 0f, bool isPenetrate = false)
    {
        this.damage = damage;
        this.range = range;
        this.isLauncher = isLauncher;
        this.explosionRadius = explosionRadius;
        this.isPenetrate = isPenetrate;

        Destroy(gameObject, range / speed);
    }

    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    void OnTriggerEnter(Collider other)
    {
        {
            if (other.CompareTag("Enemy"))
            {
                // 일반 적 처리
                other.GetComponent<Enemy>()?.TakeDamage(damage);
            }
            else if (other.CompareTag("Boss"))
            {
                // 보스 몬스터 처리
                other.GetComponent<BossAI>()?.TakeDamage(damage);
            }

            if (!isLauncher && !isPenetrate)
                Destroy(gameObject);
        }
    }

    void Explode()
    {
        // 여기에 폭발 이펙트 추가 가능
       // if (explosionEffect != null)
       //    Instantiate(explosionEffect, transform.position, Quaternion.identity);

        Collider[] hits = Physics.OverlapSphere(transform.position, explosionRadius);
        foreach (var hit in hits)
        {
            if (hit.CompareTag("Enemy"))
            {
                hit.GetComponent<Enemy>()?.TakeDamage(damage);
            }
        }      
    }
}
