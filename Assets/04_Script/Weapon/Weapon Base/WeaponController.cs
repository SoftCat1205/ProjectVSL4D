using UnityEngine;

public abstract class WeaponController : MonoBehaviour
{
    [Header("Weapon Stats")]
    public WeaponScriptableObject weaponData;

    protected float _currentCooldown = 1f;

    private void FixedUpdate()
    {
        _currentCooldown -= Time.deltaTime;
        if (_currentCooldown <= 0f)
        {
            Attack();
        }
    }

    protected abstract void Attack();
}
