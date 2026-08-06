using UnityEngine;

public class EquipmentUI : MonoBehaviour
{
    [SerializeField] private EquipmentUISlot[] slots;

    private EquipmentManager _equipmentManager;

    public void Initialize(EquipmentManager equipmentManager)
    {
        _equipmentManager = equipmentManager;

        _equipmentManager.EquipmentUpdate += Refresh;

        Refresh(equipmentManager);
    }

    private void Refresh(EquipmentManager equipmentManager)
    {
        for (int i = 0; i < 4; i++)
        {
            slots[i].Display(equipmentManager.GetEquipment((ItemCategory)(i + 4)));
        }
    }
}