using UnityEngine;

public abstract class WeaponController : MonoBehaviour
{
    [Header("Weapon Stats")]
    [SerializeField] protected WeaponScriptableObject weaponData;
    public WeaponScriptableObject WeaponData => weaponData;
    public int Level => weaponData.Level;

    protected float _currentCooldown;
    public float CurrentCooldown => _currentCooldown;

    protected void Start()
    {
        _currentCooldown = weaponData.Cooldown;
    }

    protected void Update()
    {
        _currentCooldown -= Time.deltaTime;
        if (_currentCooldown <= 0f)
        {
            Attack();
            _currentCooldown = weaponData.Cooldown;
        }
    }

    protected abstract void Attack();

    public void LevelUp()
    {
        if (weaponData.NextLevelWeaponData == null)
            return;

        weaponData = weaponData.NextLevelWeaponData;

        OnLevelUp();
    }

    protected abstract void OnLevelUp();
}
