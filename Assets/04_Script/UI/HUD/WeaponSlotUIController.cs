using UnityEngine;
using UnityEngine.UI;

public class WeaponSlotUIController : MonoBehaviour
{
    [SerializeField] private Image _icon;
    [SerializeField] private Image _cooldownOverlay;
    [SerializeField] private Image[] _currentLevelDisplay = new Image[5];
    [SerializeField] private Image _emptySlotImage;
    [SerializeField] private Image _levelImage;

    public void SetWeapon(MWeaponController weapon)
    {
        if (weapon == null)
        {
            _icon = _emptySlotImage;
            return;
        }

        _icon.sprite = weapon.WeaponData.WeaponFamily.Icon;

        SetLevel(weapon.WeaponData.Level);
    }

    public void SetLevel(int Level)
    {
        for (int i = 0; i < 5; i++)
        {
            _currentLevelDisplay[i] = _emptySlotImage;
        }
        for (int i = 0; i < Level; i++)
        {
            _currentLevelDisplay[i] = _levelImage;
        }
    }
}
