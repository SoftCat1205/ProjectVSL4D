using System;
using UnityEngine;

public class PlayerEquipmentManager : MonoBehaviour
{
    public event Action<int, Equipment> EquipmentUpdate;

    [SerializeField] private Equipment[] equipmentSlots = new Equipment[4];
    public Equipment[] EquipmentSlots => equipmentSlots;

    public void PlaceEquipment(int index, Equipment equipment)
    {
        EquipmentSlots[index] = equipment;
        EquipmentUpdate?.Invoke(index, equipment);
    }

    public void RemoveEquipment(int index)
    {
        if (EquipmentSlots[index] != null)
        {
            EquipmentSlots[index] = null;
            EquipmentUpdate?.Invoke(index, null);
        }
    }

    public Equipment GetEquipment(int index)
    {
        return EquipmentSlots[index];
    }

    public bool HasEquipment(Equipment Equipment)
    {
        foreach (Equipment EquipmentSlot in EquipmentSlots)
        {
            if (EquipmentSlot == Equipment)
            {
                return true;
            }
        }
        return false;
    }
}
