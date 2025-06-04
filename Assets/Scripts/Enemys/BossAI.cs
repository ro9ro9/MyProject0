using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BossAI : MonoBehaviour
{
    public float hp = 100f;
    public GameObject rockPrefab;
    public float attackCooldown = 5f;
    public float rockThrowRange = 15f;

    Transform player;
    NavMeshAgent agent;
    float lastAttack;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        agent.SetDestination(player.position);

        if (Vector3.Distance(transform.position, player.position) < rockThrowRange && Time.time - lastAttack > attackCooldown)
        {
           // ThrowRock();
            lastAttack = Time.time;
        }
    }

   // void ThrowRock()
   // {
   //     Instantiate(rockPrefab, transform.position + Vector3.up * 2f, Quaternion.identity)
   //         .GetComponent<Rock>().LaunchTowards(player.position);
   // }

    public void TakeDamage(float dmg)
    {
        hp -= dmg;
        if (hp <= 0)
        {
            PortalManager.instance.SpawnPortal(transform.position);
            UI_Game.instance.BossDie();
            Destroy(gameObject);
        }
    }
}
