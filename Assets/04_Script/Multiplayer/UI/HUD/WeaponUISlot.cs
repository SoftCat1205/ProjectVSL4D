using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WeaponUISlot : MonoBehaviour
{
    [SerializeField] private Image icon;
    [SerializeField] private TMP_Text amountText;

    public void Display(WeaponScriptableObject? weaponData)
    {
        if (weaponData == null)
        {
            icon.enabled = false;
            amountText.text = "";
            return;
        }

        icon.enabled = true;

        icon.sprite = weaponData.Icon;
    }
}
