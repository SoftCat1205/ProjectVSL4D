using UnityEngine;

public class WingPassiveItem : PassiveItem
{
    protected override void ApplyModifier()
    {
        ps.CurrentMoveSpeed *= 1 + passiveItemData.Multiplier;
        ps.CurrentMoveSpeed *= 1 + passiveItemData.Additive;
    }
}
