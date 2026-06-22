using UnityEngine;

public class GarlicController : WeaponController
{
    protected override void Attack()
    {
        GameObject spawnedGarlic = Instantiate(weaponData.Prefab);
        spawnedGarlic.transform.position = transform.position;
        spawnedGarlic.transform.parent = transform;
    }

    protected override void OnLevelUp()
    {

    }
}
