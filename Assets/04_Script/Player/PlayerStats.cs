using System;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public CharacterScriptableObject CharacterData;
    public WeaponScriptableObject StartWeaponData;

    //Events
    public event Action<PlayerStats> PlayerDied;
    public event Action<PlayerStats> PlayerLevelUp;
    public event Action<PlayerStats> StatUpdate;

    //Player Data
    public bool IsAlive { get; private set; }

    //Current Stats
    private string _playerName;
    private float _currentMaxHealth;
    private float _currentHealth;
    private float _currentRecovery;
    private float _currentArmour;
    private float _currentAbilityHaste;
    private float _currentMoveSpeed;
    private float _currentVision;

    public string PlayerName
    {
        get { return _playerName; }
        set
        {
            if (_playerName == value)
                return;

            _playerName = value;

            StatUpdate?.Invoke(this);
        }
    }

    public float CurrentMaxHealth
    {
        get { return _currentMaxHealth; }
        set
        {
            if (_currentMaxHealth == value)
                return;

            _currentMaxHealth = value;

            StatUpdate?.Invoke(this);
        }
    }

    public float CurrentHealth
    {
        get { return _currentHealth; }
        set
        {
            if (_currentHealth == value)
                return;

            _currentHealth = value;

            StatUpdate?.Invoke(this);
        }
    }

    public float CurrentRecovery
    {
        get { return _currentRecovery; }
        set
        {
            if (_currentRecovery == value)
                return;

            _currentRecovery = value;

            StatUpdate?.Invoke(this);
        }
    }

    public float CurrentArmour
    {
        get { return _currentArmour; }
        set
        {
            if (_currentArmour == value)
                return;

            _currentArmour = value;

            StatUpdate?.Invoke(this);
        }
    }

    public float CurrentAbilityHaste
    {
        get { return _currentAbilityHaste; }
        set
        {
            if (_currentAbilityHaste == value)
                return;

            _currentAbilityHaste = value;

            StatUpdate?.Invoke(this);
        }
    }

    public float CurrentMoveSpeed
    {
        get { return _currentMoveSpeed; }
        set
        {
            if (_currentMoveSpeed == value)
                return;

            _currentMoveSpeed = value;

            StatUpdate?.Invoke(this);
        }
    }

    public float CurrentVision
    {
        get { return _currentVision; }
        set
        {
            if (_currentVision == value)
                return;

            _currentVision = value;

            StatUpdate?.Invoke(this);
        }
    }

    //Level
    [Header("EXP")]
    public int experience = 0;
    public int level = 1;
    public int experienceCap;

    [Serializable]
    public class LevelRange
    {
        public int startLevel;
        public int endLevel;
        public int experienceCapIncrease;
    }

    public List<LevelRange> levelRanges;

    //I-Frames
    [Header("I-Frames")]
    public float invincibilityDuration;
    float invincibilityTimer;
    bool isInvincible;

    void Awake()
    {
        IsAlive = true;

        if (WeaponSelector.Instance != null)
        {
            StartWeaponData = WeaponSelector.GetData();
        }

        StatUpdate?.Invoke(this);

        PlayerName = CharacterData.PlayerName;
        CurrentMaxHealth = CharacterData.MaxHealth;
        CurrentHealth = CharacterData.MaxHealth;
        CurrentRecovery = CharacterData.Recovery;
        CurrentArmour = CharacterData.Armour;
        CurrentAbilityHaste = CharacterData.AbilityHaste;
        CurrentMoveSpeed = CharacterData.MoveSpeed;
        CurrentVision = CharacterData.Vision;
    }

    void Start()
    {
        experienceCap = levelRanges[0].experienceCapIncrease;
    }

    void FixedUpdate()
    {
        if (invincibilityTimer > 0)
        {
            invincibilityTimer -= Time.deltaTime;
        }
        else if (isInvincible)
        {
            isInvincible = false;
        }
    }

    public void IncreaseExperience(int amount)
    {
        experience += amount;

        LevelUpChecker();
    }

    void LevelUpChecker()
    {
        if (experience >= experienceCap)
        {
            level++;
            PlayerLevelUp?.Invoke(this);
            experience -= experienceCap;

            int experienceCapIncrease = 0;

            foreach (LevelRange range in levelRanges)
            {
                if (level >= range.startLevel && level <= range.endLevel)
                {
                    experienceCapIncrease = range.experienceCapIncrease;
                    break;
                }
            }
            experienceCap += experienceCapIncrease;
        }
    }

    public void TakeDamage(float dmg)
    {
        if (!isInvincible)
        {
            CurrentHealth -= dmg;

            invincibilityTimer = invincibilityDuration;
            isInvincible = true;

            if (CurrentHealth <= 0f)
            {
                Die();
            }
        }
    }

    public void Die()
    {
        IsAlive = false;
        PlayerDied?.Invoke(this);
    }

    void Recover(float heal)
    {
        if (CurrentHealth >= CurrentMaxHealth)
        {
            return;
        }

        CurrentHealth += heal;

        if (CurrentHealth > CurrentMaxHealth)
        {
            CurrentHealth = CurrentMaxHealth;
        }
    }
}
