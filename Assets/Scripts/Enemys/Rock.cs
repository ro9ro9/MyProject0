using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rock : MonoBehaviour
{
    public float damage = 1f;
    public float explosionRadius = 3f;
    public float speed = 10f;
    Vector3 target;

    public void LaunchTowards(Vector3 destination)
    {
        target = destination;
    }

    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);

        if (Vector3.Distance(transform.position, target) < 0.2f)
        {
            Explode();
        }
    }

    void Explode()
    {
        Collider[] hit = Physics.OverlapSphere(transform.position, explosionRadius);
        foreach (var col in hit)
        {
            if (col.CompareTag("Player"))
                col.GetComponent<PlayerHealth>().TakeDamage((int)damage);
        }
        Destroy(gameObject);
    }
}
