using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public PlayerStats ps;
    public static EnemySpawner Instance;

    [System.Serializable]
    public class Wave
    {
        public string waveName;
        public List<EnemyGroup> enemyGroups;
        public int waveQuota;       //Total number of enemies in the wave
        public float spawnInterval;
        public int spawnCount;      // Current number of enemies spawned
    }

    [System.Serializable]
    public class EnemyGroup
    {
        public string enemyName;
        public int enemyCount;  //Total number of enemies in the group
        public int spawnCount;  //Current number of enemies spawned included in the group;
        public GameObject enemyPrefab;
    }

    public List<Wave> waves;
    public int currentWave = 0;

    [Header("Timers")]
    float spawnTimer;
    public float waveInterval;

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        ps = PlayerStats.Instance;
        CalculateEnemyQuota();
    }

    void FixedUpdate()
    {
        if (currentWave < waves.Count - 1 && waves[currentWave].spawnCount == 0)
        {
            StartCoroutine(BeginNewWave());
        }

        spawnTimer += Time.deltaTime;

        if (spawnTimer > waves[currentWave].spawnInterval)
        {
            spawnTimer = 0f;
            SpawnEnemies();
        }
    }

    IEnumerator BeginNewWave()
    {
        yield return new WaitForSeconds(waveInterval);

        if (currentWave < waves.Count - 1)
        {
            currentWave++;
            CalculateEnemyQuota();
        }
    }

    void CalculateEnemyQuota()
    {
        int currentWaveQuota = 0;
        foreach (var enemyGroup in waves[currentWave].enemyGroups)
        {
            currentWaveQuota += enemyGroup.enemyCount;
        }

        waves[currentWave].waveQuota = currentWaveQuota;
    }

    public Vector2 GetSpawnPosition()
    {
        Vector2 direction =
            UnityEngine.Random.insideUnitCircle.normalized;

        float screenHeight =
            Camera.main.orthographicSize;

        float screenWidth =
            screenHeight * Camera.main.aspect;

        return (Vector2)Camera.main.transform.position +
            new Vector2(
                direction.x * (screenWidth + 2f),
                direction.y * (screenHeight + 2f)
            );
    }

    void SpawnEnemies()
    {
        if (waves[currentWave].spawnCount < waves[currentWave].waveQuota)
        {
            foreach (var enemyGroup in waves[currentWave].enemyGroups)
            {
                if (enemyGroup.spawnCount < enemyGroup.enemyCount)
                {
                    Instantiate(enemyGroup.enemyPrefab, GetSpawnPosition(), quaternion.identity);

                    enemyGroup.spawnCount++;
                    waves[currentWave].spawnCount++;
                }
            }
        }
    }
}
