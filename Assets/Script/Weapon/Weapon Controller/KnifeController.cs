using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public class KnifeController : WeaponController
{
    public static KnifeController Instance;

    void Awake()
    {
        Instance = this;
    }

    protected override void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    protected override void Attack()
    {
        base.Attack();
        GameObject spawnedKnife = Instantiate(prefab);
        spawnedKnife.transform.position = transform.position;
        spawnedKnife.transform.parent = transform;
        spawnedKnife.GetComponent<KnifeBehaviour>().DirectionChecker();
    }
}
