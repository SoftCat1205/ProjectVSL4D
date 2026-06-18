using UnityEngine;

public class KnifeController : WeaponController
{
    protected override void Attack()
    {
        _currentCooldown = weaponData.CooldownDuration;
        GameObject spawnedKnife = Instantiate(weaponData.Prefab);
        spawnedKnife.transform.position = transform.position;
        spawnedKnife.GetComponent<KnifeBehaviour>().DirectionChecker();
    }
}