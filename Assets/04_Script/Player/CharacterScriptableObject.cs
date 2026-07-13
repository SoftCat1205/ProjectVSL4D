using UnityEngine;

[CreateAssetMenu(fileName = "CharacterScriptableObject", menuName = "ScriptableObjects/Character")]
public class CharacterScriptableObject : ScriptableObject
{
    [SerializeField] private string playerName;
    public string PlayerName => playerName;

    [SerializeField] private GameObject startingWeapon;
    public GameObject StartingWeapon => startingWeapon;

    [SerializeField] private float maxHealth;
    public float MaxHealth => maxHealth;

    [SerializeField] private float recovery;
    public float Recovery => recovery;

    [SerializeField] private float armour;
    public float Armour => armour;

    [SerializeField] private float moveSpeed;
    public float MoveSpeed => moveSpeed;

    [SerializeField] private float abilityHaste;
    public float AbilityHaste => abilityHaste;

    [SerializeField] private float vision;
    public float Vision => vision;
}