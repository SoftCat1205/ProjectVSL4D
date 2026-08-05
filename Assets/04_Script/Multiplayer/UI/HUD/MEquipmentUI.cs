using UnityEngine;

public class MEquipmentUI : MonoBehaviour
{
    private MEquipmentManager _equipmentManager;

    public void Initialize(MEquipmentManager equipmentManager)
    {
        _equipmentManager = equipmentManager;

        _equipmentManager.EquipmentUpdate += Refresh;

        Refresh();
    }

    private void Refresh()
    {

    }
}