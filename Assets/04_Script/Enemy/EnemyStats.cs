using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    PlayerStats ps;
    EnemySpawner es;
    public EnemyScriptableObject enemyData;

    [HideInInspector] public float currentMoveSpeed;
    [HideInInspector] public float currentHealth;
    [HideInInspector] public float currentDamage;

    [HideInInspector] public float despawnDistance = 20f;

    void Awake()
    {
        currentMoveSpeed = enemyData.MoveSpeed;
        currentHealth = enemyData.MaxHealth;
        currentDamage = enemyData.Damage;
    }

    void Start()
    {
        ps = PlayerStats.Instance;
        es = EnemySpawner.Instance;
    }

    void Update()
    {
        if (Vector2.Distance(transform.position, ps.transform.position) >= despawnDistance)
        {
            RespawnEnemy();
        }
    }

    public void TakeDamage(float dmg)
    {
        currentHealth -= dmg;

        if (currentHealth <= 0f)
        {
            Kill();
        }
    }

    public void Kill()
    {
        Destroy(gameObject);
        ps.IncreaseExperience(enemyData.ExperienceDrop);
    }

    void OnCollisionStay2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            ps.TakeDamage(currentDamage);
        }
    }

    void RespawnEnemy()
    {
        transform.position = es.GetSpawnPosition();
    }
}
