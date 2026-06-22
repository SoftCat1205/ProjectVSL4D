using UnityEngine;

public class WeaponBarUIController : MonoBehaviour
{
    [SerializeField] private WeaponSlotUIController[] _weaponSlotUI = new WeaponSlotUIController[4];

    public void Initialize(Player player)
    {
        for (int i = 0; i < 4; i++)
        {
            UpdateSlot(i, player.WeaponManager.GetWeapon(i));
        }
    }

    public void UpdateSlot(int index, Weapon weapon)
    {
        _weaponSlotUI[index].SetWeapon(weapon);
    }
}
