using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(fileName = "WeaponScriptableObject", menuName = "ScriptableObjects/Weapons")]
public class WeaponScriptableObject : ScriptableObject
{
    [Header("Weapon Stats")]
    [SerializeField] private GameObject controller;
    public GameObject Controller { get => controller; private set => controller = value; }

    [SerializeField] private GameObject prefab;
    public GameObject Prefab { get => prefab; private set => prefab = value; }

    [SerializeField] private WeaponFamilyScriptableObject weaponFamily;
    public WeaponFamilyScriptableObject WeaponFamily { get => weaponFamily; private set => weaponFamily = value; }

    [SerializeField] private float damage;
    public float Damage { get => damage; private set => damage = value; }

    [SerializeField] private float speed;
    public float Speed { get => speed; private set => speed = value; }

    [SerializeField] private float cooldownDuration;
    public float CooldownDuration { get => cooldownDuration; private set => cooldownDuration = value; }

    [SerializeField] private int level;
    public int Level { get => level; private set => level = value; }

    [SerializeField] private GameObject nextLevelPrefab;
    public GameObject NextLevelPrefab { get => nextLevelPrefab; private set => nextLevelPrefab = value; }
}
