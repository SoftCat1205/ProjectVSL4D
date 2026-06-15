using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    private EnemySpawner es;
    public EnemyScriptableObject enemyData;

    [SerializeField] public float currentMoveSpeed;
    [SerializeField] private float currentHealth;
    [SerializeField] private float currentDamage;
    [SerializeField] private Player currentTarget;

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
        float shortestDistance = Mathf.Infinity;
        Player closestPlayer = null;

        foreach (Player player in PlayerManager.Instance.Players)
        {
            if (!player.Stats.IsAlive)
                continue;

            float distance = Vector3.Distance(transform.position, player.transform.position);

            if (distance < shortestDistance)
            {
                shortestDistance = distance;
                closestPlayer = player;
            }
        }

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
        if (other.TryGetComponent(out Player player))
        {
            player.Stats.TakeDamage(currentDamage);
        }
    }

    private void RespawnEnemy()
    {
        transform.position = es.GetSpawnPosition();
    }
}
