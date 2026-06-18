using UnityEngine;

public class SpinachEquipment : Equipment
{
    protected override void ApplyModifier()
    {
        equipmentManager.Multiplier *= 1 + EquipmentData.Multiplier;
        equipmentManager.Additive += EquipmentData.Additive;
    }
}