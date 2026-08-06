using UnityEngine;

public class WeaponUI : MonoBehaviour
{
    [SerializeField] private WeaponUISlot[] slots;

    private WeaponManager _weaponManager;

    public void Initialize(WeaponManager weaponManager)
    {
        _weaponManager = weaponManager;

        _weaponManager.WeaponUpdate += Refresh;

        Refresh(weaponManager);
    }

    private void Refresh(WeaponManager weaponManager)
    {
        for (int i = 0; i < 4; i++)
        {
            slots[i].Display(weaponManager.GetWeapon((ItemCategory)(i)));
        }
    }
}