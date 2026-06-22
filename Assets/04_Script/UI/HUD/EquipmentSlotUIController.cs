using UnityEngine;
using UnityEngine.UI;

public class EquipmentSlotUIContoller : MonoBehaviour
{
    [SerializeField] private Image icon;
    [SerializeField] private Image cooldownOverlay;
    [SerializeField] private Image[] currentLevelDisplay;
    [SerializeField] private Image emptySlotImage;
    [SerializeField] private Image levelImage;

    public void SetEquipment(Equipment equipment)
    {
        if (equipment == null)
        {
            icon = emptySlotImage;
            return;
        }

        icon.sprite = equipment.EquipmentData.Icon;
    }
}
