using UnityEngine;

public class MWeaponBehaviour : MonoBehaviour
{
    [SerializeField] protected WeaponScriptableObject weaponData;
    public WeaponScriptableObject WeaponData => weaponData;

    public float DestoryAfterSeconds;
    protected float currentDamage;

    protected virtual void Awake()
    {
        currentDamage = WeaponData.Damage;
    }

    protected virtual void Start()
    {
        Destroy(gameObject, DestoryAfterSeconds);
    }

    protected virtual void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Enemy") || col.CompareTag("Player"))
        {
            EnemyStats enemy = col.GetComponent<EnemyStats>();
            enemy.TakeDamage(GetCurrentDamage());
        }
    }

    protected float GetCurrentDamage()
    {
        return currentDamage;
    }
}