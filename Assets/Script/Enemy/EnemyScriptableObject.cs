using UnityEngine;

[CreateAssetMenu(fileName = "EnemyScriptableObject", menuName = "ScriptableObjects/Enemy")]
public class EnemyScriptableObject : ScriptableObject
{
    [Header("Enemy Stats")]
    [SerializeField] GameObject prefab;
    public GameObject Prefab { get => prefab; private set => prefab = value; }

    [SerializeField] float moveSpeed;
    public float MoveSpeed { get => moveSpeed; private set => moveSpeed = value; }

    [SerializeField] float maxHealth;
    public float MaxHealth { get => maxHealth; private set => maxHealth = value; }

    [SerializeField] float damage;
    public float Damage { get => damage; private set => damage = value; }
}
