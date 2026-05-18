using Unity.VisualScripting;
using UnityEngine;

public class KnifeBehaviour : ProjectileWeaponBehaviour
{
    KnifeController kc;
    Vector3 dir;

    protected override void Start()
    {
        kc = KnifeController.Instance;
        base.Start();
        dir = pm.lastDir.normalized;
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        transform.position += dir * kc.speed * Time.deltaTime;
    }
}
