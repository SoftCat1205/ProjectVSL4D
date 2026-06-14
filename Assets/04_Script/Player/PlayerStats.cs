using System;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    //Reference
    public static PlayerStats Instance;

    public event Action<PlayerStats> PlayerDied;
    public event Action<PlayerStats> PlayerLeveledUp;

    public CharacterScriptableObject characterData;
    public WeaponScriptableObject weaponData;

    //Current Stats
    [HideInInspector] public string playerName;
    [HideInInspector] public float currentMaxHealth;
    [HideInInspector] public float currentHealth;
    [HideInInspector] public float currentRecovery;
    [HideInInspector] public float currentArmour;
    [HideInInspector] public float currentAbilityHaste;
    [HideInInspector] public float currentMoveSpeed;
    [HideInInspector] public float currentVision;

    public string PlayerName
    {
        get { return playerName; }
        set
        {
            if (playerName == value)
                return;

            playerName = value;
            if (GameManager.Instance != null)
            {
                GameManager.Instance.playerNameDisplay.text = PlayerName;
            }
        }
    }

    public float CurrentMaxHealth
    {
        get { return currentMaxHealth; }
        set
        {
            if (currentMaxHealth == value)
                return;

            currentMaxHealth = value;
            if (GameManager.Instance != null)
            {
                GameManager.Instance.currentRecoveryDisplay.text = "Max Health: " + CurrentMaxHealth;
            }
        }
    }

    public float CurrentHealth
    {
        get { return currentHealth; }
        set
        {
            if (currentHealth == value)
                return;

            currentHealth = value;
            if (GameManager.Instance != null)
            {
                GameManager.Instance.currentHealthDisplay.text = "Current Health: " + CurrentHealth;
            }
        }
    }

    public float CurrentRecovery
    {
        get { return currentRecovery; }
        set
        {
            if (currentHealth == value)
                return;

            currentRecovery = value;
            if (GameManager.Instance != null)
            {
                GameManager.Instance.currentRecoveryDisplay.text = "Recovery: " + CurrentRecovery;
            }
        }
    }

    public float CurrentArmour
    {
        get { return currentArmour; }
        set
        {
            if (currentHealth == value)
                return;

            currentArmour = value;
            if (GameManager.Instance != null)
            {
                GameManager.Instance.currentArmourDisplay.text = "Armour: " + CurrentArmour;
            }
        }
    }

    public float CurrentAbilityHaste
    {
        get { return currentAbilityHaste; }
        set
        {
            if (currentHealth == value)
                return;

            currentAbilityHaste = value;
            if (GameManager.Instance != null)
            {
                GameManager.Instance.currentAbilityHasteDisplay.text = "Ability Haste: " + CurrentAbilityHaste;
            }
        }
    }

    public float CurrentMoveSpeed
    {
        get { return currentMoveSpeed; }
        set
        {
            if (currentHealth == value)
                return;

            currentMoveSpeed = value;
            if (GameManager.Instance != null)
            {
                GameManager.Instance.currentMoveSpeedDisplay.text = "Move Speed: " + CurrentMoveSpeed;
            }
        }
    }

    public float CurrentVision
    {
        get { return currentVision; }
        set
        {
            if (currentHealth == value)
                return;

            currentVision = value;
            if (GameManager.Instance != null)
            {
                GameManager.Instance.currentVisionDisplay.text = "Vision: " + CurrentVision;
            }
        }
    }

    //Level
    [Header("EXP")]
    public int experience = 0;
    public int level = 1;
    public int experienceCap;

    [System.Serializable]
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
        Instance = this;

        if (WeaponSelector.Instance != null)
        {
            weaponData = WeaponSelector.GetData();
        }

        PlayerName = characterData.PlayerName;
        CurrentMaxHealth = characterData.MaxHealth;
        CurrentHealth = characterData.MaxHealth;
        CurrentRecovery = characterData.Recovery;
        CurrentArmour = characterData.Armour;
        CurrentAbilityHaste = characterData.AbilityHaste;
        CurrentMoveSpeed = characterData.MoveSpeed;
        CurrentVision = characterData.Vision;
    }

    void Start()
    {
        experienceCap = levelRanges[0].experienceCapIncrease;

        GameManager.Instance.playerNameDisplay.text = PlayerName;
        GameManager.Instance.currentMaxHealthDisplay.text = "Max Health: " + CurrentMaxHealth;
        GameManager.Instance.currentHealthDisplay.text = "Current Health: " + CurrentHealth;
        GameManager.Instance.currentRecoveryDisplay.text = "Recovery: " + CurrentRecovery;
        GameManager.Instance.currentArmourDisplay.text = "Armour: " + CurrentArmour;
        GameManager.Instance.currentAbilityHasteDisplay.text = "Ability Haste: " + CurrentAbilityHaste;
        GameManager.Instance.currentMoveSpeedDisplay.text = "Move Speed: " + CurrentMoveSpeed;
        GameManager.Instance.currentVisionDisplay.text = "Vision: " + CurrentVision;
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
        Recover();
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
            PlayerLeveledUp?.Invoke(this);
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
                Kill();
            }
        }
    }

    public void Kill()
    {
        PlayerDied?.Invoke(this);
    }

    void Recover()
    {
        if (CurrentHealth < characterData.MaxHealth)
        {
            CurrentHealth += CurrentRecovery * Time.deltaTime;

            if (CurrentHealth > characterData.MaxHealth)
            {
                CurrentHealth = characterData.MaxHealth;
            }
        }
    }
}
