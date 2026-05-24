using Unity.VisualScripting;
using UnityEngine;

public class KnifeBehaviour : ProjectileWeaponBehaviour
{
    Vector3 dir;

    protected override void Start()
    {
        base.Start();
        dir = pm.lastDir.normalized;
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        transform.position += dir * currentSpeed * Time.deltaTime;
    }
}
