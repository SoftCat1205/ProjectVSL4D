using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    PlayerStats ps;
    public EnemyScriptableObject enemyData;

    float currentMoveSpeed;
    float currentHealth;
    float currentDamage;

    void Awake()
    {
        ps = PlayerStats.Instance;

        currentMoveSpeed = enemyData.MoveSpeed;
        currentHealth = enemyData.MaxHealth;
        currentDamage = enemyData.Damage;
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
}
