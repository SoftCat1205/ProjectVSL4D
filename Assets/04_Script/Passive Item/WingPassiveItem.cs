using UnityEngine;

public class WingPassiveItem : PassiveItem
{
    protected override void ApplyModifier()
    {
        player.Stats.CurrentMoveSpeed *= 1 + PassiveItemData.Multiplier;
        player.Stats.CurrentMoveSpeed *= 1 + PassiveItemData.Additive;
    }
}
