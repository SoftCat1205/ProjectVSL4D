using UnityEngine;

public class EquipmentBarUIContoller : MonoBehaviour
{
    [SerializeField] private EquipmentSlotUIContoller[] EquipmentBarUI = new EquipmentSlotUIContoller[4];

    public void UpdateSlot(int index, Equipment equipment)
    {
        EquipmentBarUI[index].SetEquipment(equipment);
    }
}
