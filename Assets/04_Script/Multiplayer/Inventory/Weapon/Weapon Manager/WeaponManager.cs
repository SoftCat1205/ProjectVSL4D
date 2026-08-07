using System;
using System.Collections.Generic;
using Fusion;
using UnityEngine;

public class WeaponManager : NetworkBehaviour
{
    private Dictionary<ItemCategory, WeaponSlot> weaponSlots;

    public event Action<WeaponManager> WeaponUpdate;

    public void EquipWeapon(WeaponScriptableObject weaponData, ItemCategory itemCategory)
    {
        weaponSlots[itemCategory].EquipWeapon(weaponData);

        WeaponUpdate?.Invoke(this);
    }

    public WeaponScriptableObject UnequipWeapon(ItemCategory itemCategory)
    {
        WeaponScriptableObject temp = weaponSlots[itemCategory].UnequipWeapon();

        WeaponUpdate?.Invoke(this);

        return temp;
    }

    public WeaponScriptableObject GetWeapon(ItemCategory itemCategory)
    {
        return weaponSlots[itemCategory].WeaponData;
    }

    public void Activate(NetworkInputData input, Vector2 direction)
    {
        if (input.Buttons.IsSet(InputButtons.LeftArm))
        {
            if (weaponSlots[ItemCategory.LeftArm] != null)
                weaponSlots[ItemCategory.LeftArm].Activate(direction);
        }

        if (input.Buttons.IsSet(InputButtons.RightArm))
        {
            if (weaponSlots[ItemCategory.RightArm] != null)
                weaponSlots[ItemCategory.RightArm].Activate(direction);
        }

        if (input.Buttons.IsSet(InputButtons.LeftBack))
        {
            if (weaponSlots[ItemCategory.LeftBack] != null)
                weaponSlots[ItemCategory.LeftBack].Activate(direction);
        }

        if (input.Buttons.IsSet(InputButtons.RightBack))
        {
            if (weaponSlots[ItemCategory.RightBack] != null)
                weaponSlots[ItemCategory.RightBack].Activate(direction);
        }
    }
}