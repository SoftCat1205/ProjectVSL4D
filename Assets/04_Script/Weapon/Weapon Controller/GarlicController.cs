using UnityEngine;

public class GarlicController : WeaponController
{
    protected override void Attack()
    {
        _currentCooldown = weaponData.CooldownDuration;
        GameObject spawnedGarlic = Instantiate(weaponData.Prefab);
        spawnedGarlic.transform.position = transform.position;
        spawnedGarlic.transform.parent = transform;
    }
}
