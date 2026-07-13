using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "WeaponScriptableObject", menuName = "ScriptableObjects/Weapons")]
public class WeaponScriptableObject : ItemScriptableObject
{
    [Header("Weapon Stats")]

    [SerializeField] private GameObject prefab;
    public GameObject Prefab => prefab;

    [SerializeField] private List<WeaponCategory> category;
    public List<WeaponCategory> Category => category;

    [SerializeField] private float damage;
    public float Damage => damage;

    [SerializeField] private float speed;
    public float Speed => speed;

    [SerializeField] private float cooldown;
    public float Cooldown => cooldown;

    [SerializeField] private float lifetime;
    public float Lifetime => lifetime;

    [SerializeField] private int level;
    public int Level => level;

    [SerializeField] private WeaponScriptableObject nextLevelWeaponData;
    public WeaponScriptableObject NextLevelWeaponData => nextLevelWeaponData;
}
