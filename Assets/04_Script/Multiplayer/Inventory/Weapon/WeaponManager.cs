using System;
using System.Collections.Generic;
using Fusion;
using UnityEngine;

public class WeaponManager : NetworkBehaviour
{
    [Header("Weapon Positions")]
    [SerializeField] private Dictionary<ItemCategory, Transform> weaponPositions = new(4);

    [Header("Weapon Slots")]
    [SerializeField] private Dictionary<ItemCategory, WeaponScriptableObject> equippedWeapons = new(4);
    public IEnumerable<WeaponScriptableObject> EquippedWeapons => equippedWeapons.Values;

    public event Action<WeaponManager> WeaponUpdate;

    public void EquipWeapon(WeaponScriptableObject weapon, ItemCategory itemCategory)
    {
        Runner.Spawn(weapon.Weapon, weaponPositions[itemCategory].position, weaponPositions[itemCategory].rotation);

        equippedWeapons[itemCategory] = weapon;

        weapon.Weapon.transform.SetParent(weaponPositions[itemCategory]);
        weapon.Weapon.Initialize(weapon);

        WeaponUpdate?.Invoke(this);
    }

    public WeaponScriptableObject UnequipWeapon(ItemCategory itemCategory)
    {
        if (!equippedWeapons.TryGetValue(itemCategory, out WeaponScriptableObject weapon))
            return null;

        Runner.Despawn(weapon.Weapon.NetworkObject);

        equippedWeapons[itemCategory] = null;

        WeaponUpdate?.Invoke(this);

        return weapon;
    }

    public WeaponScriptableObject GetWeapon(ItemCategory itemCategory)
    {
        equippedWeapons.TryGetValue(itemCategory, out WeaponScriptableObject weapon);
        return weapon;
    }

    public WeaponScriptableObject GetWeapon(int slot)
    {
        equippedWeapons.TryGetValue((ItemCategory)slot, out WeaponScriptableObject weapon);
        return weapon;
    }

    public void Activate(NetworkInputData input, Vector2 direction)
    {
        if (input.Buttons.IsSet(InputButtons.LeftArm))
        {
            if (equippedWeapons[ItemCategory.LeftArm] != null)
                equippedWeapons[ItemCategory.LeftArm].Weapon.Activate(direction);
        }

        if (input.Buttons.IsSet(InputButtons.RightArm))
        {
            if (equippedWeapons[ItemCategory.RightArm] != null)
                equippedWeapons[ItemCategory.RightArm].Weapon.Activate(direction);
        }

        if (input.Buttons.IsSet(InputButtons.LeftBack))
        {
            if (equippedWeapons[ItemCategory.LeftBack] != null)
                equippedWeapons[ItemCategory.LeftBack].Weapon.Activate(direction);
        }

        if (input.Buttons.IsSet(InputButtons.RightBack))
        {
            if (equippedWeapons[ItemCategory.RightBack] != null)
                equippedWeapons[ItemCategory.RightBack].Weapon.Activate(direction);
        }
    }
}