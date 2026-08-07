using Fusion;
using UnityEngine;

public class WeaponSlot : NetworkBehaviour
{
    [Header("Weapon Position")]
    [SerializeField] private Transform Mount;

    public WeaponScriptableObject WeaponData { get; set; }
    private Weapon weapon;

    public void EquipWeapon(WeaponScriptableObject weaponData)
    {
        WeaponData = weaponData;
        weapon = weaponData.Weapon.GetComponent<Weapon>();

        Runner.Spawn(WeaponData.Weapon, Mount.position, Mount.rotation);

        WeaponData.Weapon.transform.SetParent(Mount);
        weapon.Initialize(weaponData);
    }

    public WeaponScriptableObject UnequipWeapon()
    {
        if (WeaponData == null && weapon == null)
            return null;

        Runner.Despawn(WeaponData.Weapon);

        WeaponData = null;
        weapon = null;

        return WeaponData;
    }

    public void Activate(Vector2 direction)
    {
        weapon.Activate(direction);
    }
}