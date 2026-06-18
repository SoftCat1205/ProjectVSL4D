using System;
using UnityEngine;

public class PlayerWeaponManager : MonoBehaviour
{
    public event Action<int, Weapon> WeaponUpdate;

    [SerializeField] private Weapon[] weaponSlots = new Weapon[4];
    public Weapon[] WeaponSlots => weaponSlots;

    public void PlaceWeapon(int index, Weapon weapon)
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

    public Weapon GetWeapon(int index)
    {
        return weaponSlots[index];
    }

    public bool HasWeapon(Weapon weapon)
    {
        foreach (Weapon weaponSlot in weaponSlots)
        {
            if (weaponSlot == weapon)
            {
                return true;
            }
        }
        return false;
    }
}
