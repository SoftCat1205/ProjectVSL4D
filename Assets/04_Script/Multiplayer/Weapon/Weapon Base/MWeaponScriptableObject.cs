using UnityEngine;

[CreateAssetMenu(fileName = "WeaponScriptableObject", menuName = "ScriptableObjects/Weapons")]
public class WeaponScriptableObject : ScriptableObject
{
    [Header("Weapon Stats")]

    [SerializeField] private GameObject prefab;
    public GameObject Prefab { get => prefab; private set => prefab = value; }

    [SerializeField] private WeaponFamilyScriptableObject weaponFamily;
    public WeaponFamilyScriptableObject WeaponFamily { get => weaponFamily; private set => weaponFamily = value; }

    [SerializeField] private float damage;
    public float Damage { get => damage; private set => damage = value; }

    [SerializeField] private float speed;
    public float Speed { get => speed; private set => speed = value; }

    [SerializeField] private float cooldown;
    public float Cooldown { get => cooldown; private set => cooldown = value; }

    [SerializeField] private int level;
    public int Level { get => level; private set => level = value; }

    [SerializeField] private WeaponScriptableObject nextLevelWeaponData;
    public WeaponScriptableObject NextLevelWeaponData { get => nextLevelWeaponData; private set => nextLevelWeaponData = value; }
}
