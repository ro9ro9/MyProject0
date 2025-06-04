using UnityEngine;

public class KillCounter : MonoBehaviour
{
    public static KillCounter instance;
    public int enemyKillCount = 0;
    public bool bossSpawned = false;

    void Awake() => instance = this;

    public void AddKill()
    {
        enemyKillCount++;

        UI_Game.instance.UpdateKillCount(enemyKillCount);

        if (enemyKillCount >= 100 && !bossSpawned)
        {
            bossSpawned = true;
            BossSpawner.instance.SpawnBoss();
        }
    }
}
