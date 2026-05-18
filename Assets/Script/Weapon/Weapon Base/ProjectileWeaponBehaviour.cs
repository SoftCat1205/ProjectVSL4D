using System;
using UnityEngine;

public class ProjectileWeaponBehaviour : MonoBehaviour
{
    public float destoryAfterSeconds;
    protected PlayerMovement pm;

    protected virtual void Awake()
    {
        pm = PlayerMovement.Instance;
    }

    protected virtual void Start()
    {
        Destroy(gameObject, destoryAfterSeconds);
    }

    public void DirectionChecker()
    {
        float angle =
            Mathf.Atan2(pm.lastDir.y, pm.lastDir.x) * Mathf.Rad2Deg + 315f;

        transform.rotation =
            Quaternion.Euler(0, 0, angle);
    }
}
