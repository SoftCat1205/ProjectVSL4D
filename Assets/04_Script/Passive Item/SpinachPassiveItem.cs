using UnityEngine;

public class SpinachPassiveItem : PassiveItem
{
    protected override void ApplyModifier()
    {
        ps.CurrentAbilityHaste *= 1 + passiveItemData.Multiplier;
        ps.CurrentAbilityHaste *= 1 + passiveItemData.Additive;
    }
}
