using Fusion;
using UnityEngine;

public class MTestProjectileWeaponController : MWeaponController
{
    public override void Activate(Vector2 direction)
    {
        Debug.Log(weaponData.Prefab);
        NetworkObject projectile = Runner.Spawn(weaponData.Prefab, transform.position, Quaternion.identity);

        projectile.GetComponent<MWeaponBehaviourProjectileTest>().Initialize(direction);
    }
}