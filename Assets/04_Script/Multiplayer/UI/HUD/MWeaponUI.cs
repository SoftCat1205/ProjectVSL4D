using UnityEngine;

public class MWeaponUI : MonoBehaviour
{
    private MWeaponManager _weaponManager;

    public void Initialize(MWeaponManager weaponManager)
    {
        _weaponManager = weaponManager;

        _weaponManager.WeaponUpdate += Refresh;

        Refresh();
    }

    private void Refresh()
    {

    }
}