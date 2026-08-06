using Fusion;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUISlot : MonoBehaviour
{
    [SerializeField] private Image icon;
    [SerializeField] private TMP_Text amountText;

    public void Display(InventoryItem? item, ItemScriptableObject? itemData)
    {
        if (item == null || itemData == null)
        {
            icon.enabled = false;
            amountText.text = "";
            return;
        }

        icon.enabled = true;

        icon.sprite = itemData.Icon;
        amountText.text = item.Count.ToString();
    }
}
