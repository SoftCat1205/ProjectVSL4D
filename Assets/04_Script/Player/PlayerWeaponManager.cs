using System;
using UnityEngine;

public class PlayerWeaponManager : MonoBehaviour
{
    public event Action<int, MWeaponController> WeaponUpdate;

    [SerializeField] private MWeaponController[] weaponSlots = new MWeaponController[4];
    public MWeaponController[] WeaponSlots => weaponSlots;

    public void PlaceWeapon(int index, MWeaponController weapon)
    {
        WeaponSlots[index] = weapon;
        WeaponUpdate?.Invoke(index, weapon);
    }

    public void RemoveWeapon(int index)
    {
        if (WeaponSlots[index] != null)
        {
            WeaponSlots[index] = null;
            WeaponUpdate?.Invoke(index, null);
        }
    }

    public void UpgradeWeapon(int index)
    {
        weaponSlots[index].LevelUp();
    }

    public MWeaponController GetWeapon(int index)
    {
        return weaponSlots[index];
    }

    public bool HasWeapon(MWeaponController weapon)
    {
        foreach (MWeaponController weaponSlot in weaponSlots)
        {
            if (weaponSlot == weapon)
            {
                return true;
            }
        }
        return false;
    }
}
