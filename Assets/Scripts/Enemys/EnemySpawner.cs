using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public Transform[] spawnPoints;
    public float spawnInterval = 0.1f;
    public int maxEnemies = 1000;
    private List<GameObject> activeEnemies = new List<GameObject>();

    void Start()
    {
        InvokeRepeating(nameof(SpawnEnemy), 1f, spawnInterval);
    }

    void SpawnEnemy()
    {
        if (spawnPoints.Length == 0)
        {
            Debug.LogWarning("SpawnPoints가 비어 있습니다. 스폰하지 않습니다.");
            return;
        }

        if (activeEnemies.Count >= maxEnemies) return;

        int index = Random.Range(0, spawnPoints.Length);
        GameObject z = Instantiate(enemyPrefab, spawnPoints[index].position, Quaternion.identity);
        activeEnemies.Add(z);
    }

    public void RemoveEnemy(GameObject Enemy)
    {
        activeEnemies.Remove(Enemy);
    }
}
