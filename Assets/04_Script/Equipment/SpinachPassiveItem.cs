using UnityEngine;

public class SpinachEquipment : Equipment
{
    protected override void ApplyModifier()
    {
        EquipmentCalculator.Multiplier *= 1 + EquipmentData.Multiplier;
        EquipmentCalculator.Additive += EquipmentData.Additive;
    }
}