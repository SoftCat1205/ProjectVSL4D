using UnityEngine;

[CreateAssetMenu(fileName = "CharacterScriptableObject", menuName = "ScriptableObjects/Character")]
public class CharacterScriptableObject : ScriptableObject
{
    [SerializeField] private string playerName;
    public string PlayerName { get => playerName; private set => playerName = value; }

    [SerializeField] private GameObject startingWeapon;
    public GameObject StartingWeapon { get => startingWeapon; private set => startingWeapon = value; }

    [SerializeField] private float maxHealth;
    public float MaxHealth { get => maxHealth; private set => maxHealth = value; }

    [SerializeField] private float recovery;
    public float Recovery { get => recovery; private set => recovery = value; }

    [SerializeField] private float armour;
    public float Armour { get => armour; private set => armour = value; }

    [SerializeField] private float moveSpeed;
    public float MoveSpeed { get => moveSpeed; private set => moveSpeed = value; }

    [SerializeField] private float abilityHaste;
    public float AbilityHaste { get => abilityHaste; private set => abilityHaste = value; }

    [SerializeField] private float vision;
    public float Vision { get => vision; private set => vision = value; }
}