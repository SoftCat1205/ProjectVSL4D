using UnityEngine;

public class WingEquipment : Equipment
{
    protected override void ApplyModifier()
    {
        equipmentManager.Multiplier *= 1 + EquipmentData.Multiplier;
        equipmentManager.Additive += EquipmentData.Additive;
    }
}