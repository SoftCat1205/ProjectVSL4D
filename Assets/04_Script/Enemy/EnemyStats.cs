using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    private EnemySpawner es;
    public EnemyScriptableObject enemyData;

    [SerializeField] public float currentMoveSpeed;
    [SerializeField] private float currentHealth;
    [SerializeField] private float currentDamage;
    [SerializeField] private Transform currentTarget;

    [SerializeField] private float despawnDistance = 20f;
    [SerializeField] private float shortestDistance;

    private void Awake()
    {
        currentMoveSpeed = enemyData.MoveSpeed;
        currentHealth = enemyData.MaxHealth;
        currentDamage = enemyData.Damage;
    }

    private void Start()
    {
        es = EnemySpawner.Instance;
    }

    private void Update()
    {
        FindClosestPlayer();
        if (shortestDistance >= despawnDistance)
        {
            RespawnEnemy();
        }
    }

    private void FindClosestPlayer()
    {
        Transform closestPlayer = null;

        currentTarget = closestPlayer;
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
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Transform player))
        {
        }
    }

    private void RespawnEnemy()
    {
        transform.position = es.GetSpawnPosition();
    }
}
