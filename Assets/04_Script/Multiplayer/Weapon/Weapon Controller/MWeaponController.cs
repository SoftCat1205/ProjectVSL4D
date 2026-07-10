using Fusion;
using UnityEngine;

public class MWeaponController : NetworkBehaviour
{
    [Networked] public NetworkObject Owner { get; set; }
    [Networked] public int SlotIndex { get; set; }


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

    public virtual void Activate(Vector2 direction)
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