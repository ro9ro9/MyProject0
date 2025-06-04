using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSpawner : MonoBehaviour
{
    public static BossSpawner instance;
    public GameObject bossPrefab;
    public Transform spawnPoint;

    void Awake() => instance = this;

    public void SpawnBoss()
    {
        Instantiate(bossPrefab, spawnPoint.position, Quaternion.identity);
    }
}
