using UnityEngine;

public class SpinachPassiveItem : PassiveItem
{
    protected override void ApplyModifier()
    {
        player.Stats.CurrentAbilityHaste *= 1 + PassiveItemData.Multiplier;
        player.Stats.CurrentAbilityHaste *= 1 + PassiveItemData.Additive;
    }
}
