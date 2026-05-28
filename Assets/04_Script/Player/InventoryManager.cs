using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance;

    public List<WeaponController> weaponSlots = new(6);
    public int[] weaponLevels = new int[6];
    public List<PassiveItem> passiveItemSlots = new(6);
    public int[] passiveItemLevels = new int[6];

    void Awake()
    {
        Instance = this;
    }

    public void AddWeapon(int slotIndex, WeaponController weapon)
    {
        weaponSlots[slotIndex] = weapon;
    }

    public void AddPassiveItem(int slotIndex, PassiveItem passiveItem)
    {
        passiveItemSlots[slotIndex] = passiveItem;
    }

    public void LevelUpWeapon(int slotIndex)
    {
        weaponLevels[slotIndex]++;
    }

    public void LevelUpPassiveItem(int slotIndex)
    {
        passiveItemLevels[slotIndex]++;
    }
}
