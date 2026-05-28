using UnityEngine;

public class SpinachPassiveItem : PassiveItem
{
    protected override void ApplyModifier()
    {
        ps.currentMight *= 1 + passiveItemData.Multiplier;
        ps.currentMight *= 1 + passiveItemData.Additive;
    }
}
