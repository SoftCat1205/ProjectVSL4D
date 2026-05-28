using UnityEngine;

public class WingPassiveItem : PassiveItem
{
    protected override void ApplyModifier()
    {
        ps.currentMoveSpeed *= 1 + passiveItemData.Multiplier;
        ps.currentMoveSpeed *= 1 + passiveItemData.Additive;
    }
}
