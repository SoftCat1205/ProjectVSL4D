using UnityEngine;

[CreateAssetMenu(fileName = "CharacterScriptableObject", menuName = "ScriptableObjects/Character")]
public class CharacterScriptableObject : ScriptableObject
{
    [SerializeField] GameObject startingWeapon;
    public GameObject StartingWeapon { get => startingWeapon; private set => startingWeapon = value; }

    [SerializeField] float maxHealth;
    public float MaxHealth { get => maxHealth; private set => maxHealth = value; }

    [SerializeField] float recovery;
    public float Recovery { get => recovery; private set => recovery = value; }

    [SerializeField] float armour;
    public float Armour { get => armour; private set => armour = value; }

    [SerializeField] float moveSpeed;
    public float MoveSpeed { get => moveSpeed; private set => moveSpeed = value; }

    [SerializeField] float abilityHaste;
    public float AbilityHaste { get => abilityHaste; private set => abilityHaste = value; }

    [SerializeField] float vision;
    public float Vision { get => vision; private set => vision = value; }
}