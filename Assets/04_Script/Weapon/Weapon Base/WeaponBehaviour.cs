using System;
using UnityEngine;

public class WeaponBehaviour : MonoBehaviour
{
    public WeaponScriptableObject WeaponData;

    public float DestoryAfterSeconds;
    protected Player player;

    protected float currentDamage;
    protected float currentSpeed;
    protected float currentCooldownDuration;

    protected virtual void Awake()
    {
        currentDamage = WeaponData.Damage;
        currentSpeed = WeaponData.Speed;
        currentCooldownDuration = WeaponData.CooldownDuration;
    }

    protected virtual void Start()
    {

        Destroy(gameObject, DestoryAfterSeconds);
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