using System;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentManager : MonoBehaviour
{
    [Header("Equipment Slots")]
    [SerializeField] private Dictionary<ItemCategory, EquipmentScriptableObject> equippedItems = new();
    public IEnumerable<EquipmentScriptableObject> EquippedItems => equippedItems.Values;

    public event Action<EquipmentManager> EquipmentUpdate;

    public void EquipEquipment(EquipmentScriptableObject equipment, ItemCategory itemCategory)
    {
        equippedItems[itemCategory] = equipment;

        equipment.Equipment.Initialize(equipment);

        EquipmentUpdate?.Invoke(this);
    }

    public EquipmentScriptableObject UnequipEquipment(ItemCategory itemCategory)
    {
        if (!equippedItems.TryGetValue(itemCategory, out EquipmentScriptableObject equipment))
            return null;

        equippedItems[itemCategory] = null;

        EquipmentUpdate?.Invoke(this);

        return equipment;
    }

    public EquipmentScriptableObject GetEquipment(ItemCategory itemCategory)
    {
        equippedItems.TryGetValue(itemCategory, out EquipmentScriptableObject equipment);
        return equipment;
    }
}