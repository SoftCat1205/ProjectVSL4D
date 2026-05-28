using System;
using UnityEngine;

public class ProjectileWeaponBehaviour : WeaponBehaviour
{
    protected override void Awake()
    {
        pm = PlayerMovement.Instance;
        currentDamage = weaponData.Damage;
        currentSpeed = weaponData.Speed;
        currentCooldownDuration = weaponData.CooldownDuration;
    }

    public void DirectionChecker()
    {
        float angle =
            Mathf.Atan2(pm.lastDir.y, pm.lastDir.x) * Mathf.Rad2Deg + 270f;

        transform.rotation =
            Quaternion.Euler(0, 0, angle);
    }

    protected override void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Enemy"))
        {
            EnemyStats enemy = col.GetComponent<EnemyStats>();
            enemy.TakeDamage(GetCurrentDamage());
            Destroy(gameObject);
        }
    }
}
