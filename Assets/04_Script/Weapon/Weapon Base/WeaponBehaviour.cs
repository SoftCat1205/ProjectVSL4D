using System;
using UnityEngine;

public class WeaponBehaviour : MonoBehaviour
{
    public WeaponScriptableObject weaponData;

    public float destoryAfterSeconds;
    protected PlayerMovement pm;
    protected PlayerStats ps;

    protected float currentDamage;
    protected float currentSpeed;
    protected float currentCooldownDuration;

    protected virtual void Awake()
    {
        currentDamage = weaponData.Damage;
        currentSpeed = weaponData.Speed;
        currentCooldownDuration = weaponData.CooldownDuration;
    }

    protected virtual void Start()
    {
        pm = PlayerMovement.Instance;
        ps = PlayerStats.Instance;
        Destroy(gameObject, destoryAfterSeconds);
    }

    protected virtual void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Enemy"))
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