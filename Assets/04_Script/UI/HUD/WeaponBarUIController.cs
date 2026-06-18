using UnityEngine;

public class WeaponBarUIController : MonoBehaviour
{
    [SerializeField] private WeaponSlotUIController[] weaponSlotUI = new WeaponSlotUIController[4];

    public void UpdateSlot(int index, Weapon weapon)
    {
        weaponSlotUI[index].SetWeapon(weapon);
    }
}
