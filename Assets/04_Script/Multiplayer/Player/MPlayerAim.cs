using Fusion;
using UnityEngine;

public class MPlayerAim : NetworkBehaviour
{
    [SerializeField] private Transform weapon;

    public void Aim(Vector2 aimPosition)
    {
        Vector2 direction = aimPosition - (Vector2)transform.position;

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        weapon.rotation = Quaternion.Euler(0, 0, angle);
    }
}
