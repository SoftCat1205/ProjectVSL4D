using UnityEngine;

public class EquipmentBarUIContoller : MonoBehaviour
{
    [SerializeField] private EquipmentSlotUIContoller[] EquipmentBarUI = new EquipmentSlotUIContoller[4];

    public void Initialize(Player player)
    {
        for (int i = 0; i < 4; i++)
        {
            UpdateSlot(i, player.EquipmentManager.GetEquipment(i));
        }
    }

    public void UpdateSlot(int index, Equipment equipment)
    {
        EquipmentBarUI[index].SetEquipment(equipment);
    }
}
