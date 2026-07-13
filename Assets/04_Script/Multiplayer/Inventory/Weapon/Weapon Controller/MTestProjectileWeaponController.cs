using Fusion;
using UnityEngine;

public class MTestProjectileWeapon : MWeapon
{
    public override void Activate(Vector2 direction)
    {
        if (_currentCooldown <= 0f)
        {
            NetworkObject projectile = Runner.Spawn(weaponData.Prefab, transform.position, Quaternion.identity);

            projectile.GetComponent<MWeaponBehaviourProjectileTest>().Initialize(direction, weaponData);

            _currentCooldown = WeaponData.Cooldown;
        }
    }
}