using UnityEngine;
using UnityEngine.UI;

public class InventorySlotUIController : MonoBehaviour
{
    [SerializeField] private Image icon;
    [SerializeField] private Image cooldownOverlay;
    [SerializeField] private Image[] currentLevelDisplay;
    [SerializeField] private Image emptySlotImage;
    [SerializeField] private Image levelImage;

    public void Initialize(Player player)
    {

    }
}
