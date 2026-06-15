using Unity.VisualScripting;
using UnityEngine;

public class KnifeBehaviour : ProjectileWeaponBehaviour
{
    Vector3 dir;

    protected override void Start()
    {
        base.Start();
        dir = player.Movement.lastDir.normalized;
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        transform.position += currentSpeed * Time.deltaTime * dir;
    }
}
