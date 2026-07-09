using Fusion;
using UnityEngine;

public class MWeaponController : NetworkBehaviour
{
    [Header("Weapon Stats")]
    [SerializeField] protected WeaponScriptableObject weaponData;
    public WeaponScriptableObject WeaponData => weaponData;
    public int Level => WeaponData.Level;

    protected float _currentCooldown = 0;
    public float CurrentCooldown => _currentCooldown;

    protected void Update()
    {
        if (_currentCooldown > 0f)
        {
            _currentCooldown -= Time.deltaTime;
        }
    }

    public virtual void Activate()
    {
        if (_currentCooldown < 0f)
        {
            Debug.Log("Activated Weapon!");
            _currentCooldown = WeaponData.Cooldown;
        }
    }

    public void LevelUp()
    {
        if (WeaponData.NextLevelWeaponData == null)
        {
            Debug.Log("Max Level.");
            return;
        }

        weaponData = WeaponData.NextLevelWeaponData;
    }
}