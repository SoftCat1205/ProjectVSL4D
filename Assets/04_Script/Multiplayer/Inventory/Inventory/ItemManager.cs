using UnityEngine;

public class ItemManager : MonoBehaviour
{
    private InventoryManager inventory;
    private EquipmentManager equipmentManager;
    private WeaponManager weaponManager;

    private void Awake()
    {
        inventory = GetComponent<InventoryManager>();
        equipmentManager = GetComponent<EquipmentManager>();
        weaponManager = GetComponent<WeaponManager>();
    }

    public bool InventoryToSlot(int invenSlot, ItemCategory equipSlot)
    {
        ItemScriptableObject item = inventory.GetSlotData(invenSlot);

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