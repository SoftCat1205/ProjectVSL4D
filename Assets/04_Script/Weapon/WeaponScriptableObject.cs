using UnityEngine;

[CreateAssetMenu(fileName = "WeaponScriptableObject", menuName = "ScriptableObjects/Weapons")]
public class WeaponScriptableObject : ScriptableObject
{
    [Header("Weapon Stats")]
    [SerializeField] GameObject controller;
    public GameObject Controller { get => controller; private set => controller = value; }

    [SerializeField] GameObject prefab;
    public GameObject Prefab { get => prefab; private set => prefab = value; }

    [SerializeField] float damage;
    public float Damage { get => damage; private set => damage = value; }

    [SerializeField] float speed;
    public float Speed { get => speed; private set => speed = value; }

    [SerializeField] float cooldownDuration;
    public float CooldownDuration { get => cooldownDuration; private set => cooldownDuration = value; }
}
