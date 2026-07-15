using System;

[Serializable]
public struct StatModifier
{
    public PlayerStatType StatType;
    public ModifierType ModifierType;
    public float Value;
}