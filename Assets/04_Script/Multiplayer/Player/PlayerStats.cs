using Fusion;
using UnityEngine;
using System;

public class PlayerStats : NetworkBehaviour
{
    [Header("References")]
    [SerializeField] private CharacterScriptableObject characterData;
    [SerializeField] private EquipmentManager equipmentManager;

    public event Action<PlayerStats> StatsUpdate;

    // Networked
    [Networked] public float Health { get; set; }
    [Networked] public NetworkBool IsAlive { get; set; }

    // Calculated
    public float MaxHealth { get; private set; }
    public float Armour { get; private set; }
    public float MoveSpeed { get; private set; }
    public float AbilityHaste { get; private set; }
    public float Vision { get; private set; }

    public float AdditionalMaxHealth { get; private set; } = 0;
    public float AdditionalArmour { get; private set; } = 0;
    public float AdditionalMoveSpeed { get; private set; } = 0;
    public float AdditionalAbilityHaste { get; private set; } = 0;
    public float AdditionalVision { get; private set; } = 0;

    public override void Spawned()
    {
        RecalculateStats();

        if (Object.HasStateAuthority)
        {
            Health = MaxHealth;
            IsAlive = true;
        }

        StatsUpdate?.Invoke(this);
    }

    public void RecalculateStats()
    {
        ResetStats();

        CalculateEquipment();

        ClampStats();

        ApplyStats();

        StatsUpdate?.Invoke(this);
    }

    private void ResetStats()
    {
        MaxHealth = characterData.MaxHealth;
        Armour = characterData.Armour;
        MoveSpeed = characterData.MoveSpeed;
        AbilityHaste = characterData.AbilityHaste;
        Vision = characterData.Vision;
    }

    private void CalculateEquipment()
    {
        if (equipmentManager == null)
            return;

        foreach (EquipmentScriptableObject equipment in equipmentManager.EquippedItems)
        {
            foreach (StatModifier modifier in equipment.Modifiers)
            {
                ApplyModifier(modifier);
            }
        }
    }

    private void ApplyModifier(StatModifier modifier)
    {
        switch (modifier.ModifierType)
        {
            case ModifierType.Flat:
                switch (modifier.StatType)
                {
                    case PlayerStatType.MaxHealth:
                        AdditionalMaxHealth += modifier.Value;
                        break;

                    case PlayerStatType.Armour:
                        AdditionalArmour += modifier.Value;
                        break;

                    case PlayerStatType.MoveSpeed:
                        AdditionalMoveSpeed += modifier.Value;
                        break;

                    case PlayerStatType.AbilityHaste:
                        AdditionalAbilityHaste += modifier.Value;
                        break;

                    case PlayerStatType.Vision:
                        AdditionalVision += modifier.Value;
                        break;
                }
                break;

            case ModifierType.Percent:
                switch (modifier.StatType)
                {
                    case PlayerStatType.MaxHealth:
                        AdditionalMaxHealth += MaxHealth * modifier.Value;
                        break;

                    case PlayerStatType.Armour:
                        AdditionalArmour += Armour * modifier.Value;
                        break;

                    case PlayerStatType.MoveSpeed:
                        AdditionalMoveSpeed += MoveSpeed * modifier.Value;
                        break;

                    case PlayerStatType.AbilityHaste:
                        AdditionalAbilityHaste += AbilityHaste * modifier.Value;
                        break;

                    case PlayerStatType.Vision:
                        AdditionalVision += Vision * modifier.Value;
                        break;
                }
                break;
        }
    }

    public void ModifyHealth(float amount)
    {
        Health = Mathf.Clamp(Health + amount, 0, MaxHealth);

        StatsUpdate?.Invoke(this);
    }

    private void ClampStats()
    {
        if (Object.HasStateAuthority)
        {
            Health = Mathf.Min(Health, MaxHealth);
        }
    }

    private void ApplyStats()
    {
        MaxHealth += AdditionalMaxHealth;
        Armour += AdditionalArmour;
        MoveSpeed += AdditionalMoveSpeed;
        AbilityHaste += AdditionalAbilityHaste;
        Vision += AdditionalVision;
    }
}