using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EquipmentUISlot : MonoBehaviour
{
    [SerializeField] private Image icon;
    [SerializeField] private TMP_Text amountText;

    public void Display(EquipmentScriptableObject? equipmentData)
    {
        if (equipmentData == null)
        {
            icon.enabled = false;
            amountText.text = "";
            return;
        }

        icon.enabled = true;

        icon.sprite = equipmentData.Icon;
    }
}
