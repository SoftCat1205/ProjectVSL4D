using Fusion;
using UnityEngine;

public class MPlayerAim : NetworkBehaviour
{
    [SerializeField] private Transform weaponRenderer;

    public void Aim(Vector2 aimPosition)
    {
        Vector2 direction = aimPosition - (Vector2)transform.position;

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90;

        weaponRenderer.rotation = Quaternion.Euler(0, 0, angle);
    }
}
