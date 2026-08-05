using UnityEngine;
using Fusion;

public class MItemManager : NetworkBehaviour
{
    private MInventory inventory;
    private MEquipmentManager equipmentManager;
    private MWeaponManager weaponManager;

    private void Awake()
    {
        inventory = GetComponent<MInventory>();
        equipmentManager = GetComponent<MEquipmentManager>();
        weaponManager = GetComponent<MWeaponManager>();
    }

    public bool InventoryToSlot(int invenSlot, ItemCategory equipSlot)
    {
        ItemScriptableObject item = inventory.GetItemData(invenSlot);

        if (item is WeaponScriptableObject weapon)
        {
            InventoryItem temp = ConvertToInventoryItem(weaponManager.UnequipWeapon(equipSlot));
            weaponManager.EquipWeapon(weapon, equipSlot);
            inventory.PlaceItem(invenSlot, temp);

            return true;
        }

        if (item is EquipmentScriptableObject equipment)
        {
            InventoryItem temp = ConvertToInventoryItem(equipmentManager.UnequipEquipment(equipSlot));
            equipmentManager.EquipEquipment(equipment, equipSlot);
            inventory.PlaceItem(invenSlot, temp);

            return true;
        }

        return false;
    }

    public InventoryItem ConvertToInventoryItem(WeaponScriptableObject weaponScriptableObject)
    {
        return new InventoryItem(weaponScriptableObject.ItemID, 1);
    }

    public InventoryItem ConvertToInventoryItem(EquipmentScriptableObject equipmentScriptableObject)
    {
        return new InventoryItem(equipmentScriptableObject.ItemID, 1);
    }
}