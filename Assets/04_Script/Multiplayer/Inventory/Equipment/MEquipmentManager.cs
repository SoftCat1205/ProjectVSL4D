using System;
using System.Collections.Generic;
using UnityEngine;

public class MEquipmentManager : MonoBehaviour
{
    [Header("Equipment Slots")]
    [SerializeField] private Dictionary<ItemCategory, EquipmentScriptableObject> equippedItems = new();
    public IEnumerable<EquipmentScriptableObject> EquippedItems => equippedItems.Values;

    public event Action EquipmentUpdate;

    public void EquipEquipment(EquipmentScriptableObject equipment, ItemCategory itemCategory)
    {
        equippedItems[itemCategory] = equipment;

        equipment.Equipment.Initialize(equipment);

        EquipmentUpdate?.Invoke();
    }

    public EquipmentScriptableObject UnequipEquipment(ItemCategory itemCategory)
    {
        if (!equippedItems.TryGetValue(itemCategory, out EquipmentScriptableObject equipment))
            return null;

        equippedItems[itemCategory] = null;

        EquipmentUpdate?.Invoke();

        return equipment;
    }

    public EquipmentScriptableObject GetEquipment(ItemCategory itemCategory)
    {
        equippedItems.TryGetValue(itemCategory, out EquipmentScriptableObject equipment);
        return equipment;
    }
}