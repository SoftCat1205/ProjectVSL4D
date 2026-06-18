using UnityEngine;
using UnityEngine.UI;

public class WeaponSlotUIController : MonoBehaviour
{
    [SerializeField] private Image icon;
    [SerializeField] private Image cooldownOverlay;
    [SerializeField] private Image[] currentLevelDisplay;
    [SerializeField] private Image emptySlotImage;
    [SerializeField] private Image levelImage;

    public void SetWeapon(Weapon weapon)
    {
        if (weapon == null)
        {
            icon = emptySlotImage;
            return;
        }

        icon.sprite = weapon.Controller.weaponData.WeaponFamily.Icon;
        for (int i = 0; i < 5; i++)
        {
            currentLevelDisplay[i] = emptySlotImage;
        }
        for (int i = 0; i < weapon.Controller.weaponData.Level; i++)
        {
            currentLevelDisplay[i] = levelImage;
        }
    }
}
