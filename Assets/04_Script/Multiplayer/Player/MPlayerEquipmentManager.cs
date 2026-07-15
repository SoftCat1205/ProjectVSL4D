using System.Collections.Generic;
using UnityEngine;

public class MEquipmentManager : MonoBehaviour
{
    private Dictionary<EquipmentCategory, EquipmentScriptableObject> equippedItems = new();

    public IEnumerable<EquipmentScriptableObject> EquippedItems =>
        equippedItems.Values;

    public void Equip(EquipmentScriptableObject equipment)
    {
        equippedItems[equipment.Category] = equipment;
    }

    public void Unequip(EquipmentCategory slot)
    {
        equippedItems.Remove(slot);
    }

    public EquipmentScriptableObject GetEquipment(EquipmentCategory slot)
    {
        equippedItems.TryGetValue(slot, out EquipmentScriptableObject equipment);
        return equipment;
    }
}