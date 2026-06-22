using UnityEngine;

[RequireComponent(typeof(WeaponController))]
public class Weapon : MonoBehaviour
{
    public WeaponController Controller { get; private set; }
    public WeaponScriptableObject Data => Controller.WeaponData;
    public string DisplayName => Data.WeaponFamily.DisplayName;
    public int Level => Data.Level;
    public WeaponCategory Category => Data.WeaponCategory;
    public float Damage => Data.Damage;
    public float Cooldown => Data.Cooldown;

    private void Awake()
    {
        Controller = GetComponent<WeaponController>();
    }

    public void LevelUp()
    {
        Controller.LevelUp();
    }
}
