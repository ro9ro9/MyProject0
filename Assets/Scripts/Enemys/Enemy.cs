using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public float attackRange = 2f;
    public float attackCooldown = 1f;
    public float damage = 1f;

    Transform player;
    NavMeshAgent agent;
    float lastAttackTime;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        agent.SetDestination(player.position);

        float distance = Vector3.Distance(transform.position, player.position);
        if (distance <= attackRange && Time.time - lastAttackTime > attackCooldown)
        {
            player.GetComponent<PlayerHealth>().TakeDamage((int)damage);
            lastAttackTime = Time.time;
        }
    }

    public void TakeDamage(float dmg)
    {
        Destroy(gameObject);
        KillCounter.instance.AddKill();
    }
}
