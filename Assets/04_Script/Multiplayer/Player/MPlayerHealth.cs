using System;
using Fusion;
using UnityEngine;

public class MHealth : NetworkBehaviour
{
    [SerializeField] private MPlayerStats stats;

    public event Action<MHealth> Died;

    public void TakeDamage(float damage)
    {
        if (!Object.HasStateAuthority)
            return;

        damage -= stats.Armour;

        damage = Mathf.Max(1, damage);

        stats.Health -= damage;

        if (stats.Health <= 0)
        {
            stats.Health = 0;
            Died?.Invoke(this);
        }
    }

    public void Heal(float amount)
    {
        if (!Object.HasStateAuthority)
            return;

        stats.Health = Mathf.Min(stats.Health + amount, stats.MaxHealth);
    }
}