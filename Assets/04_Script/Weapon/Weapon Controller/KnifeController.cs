using UnityEngine;

public class KnifeController : WeaponController
{
    protected override void Attack()
    {
        GameObject spawnedKnife = Instantiate(weaponData.Prefab);
        spawnedKnife.transform.position = transform.position;
        spawnedKnife.GetComponent<KnifeBehaviour>().DirectionChecker();
    }

    protected override void OnLevelUp()
    {

    }
}