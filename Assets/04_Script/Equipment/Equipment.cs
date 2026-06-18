using Unity.VisualScripting;
using UnityEngine;

public class Equipment : MonoBehaviour
{
    public EquipmentScriptableObject EquipmentData;
    public EquipmentManager equipmentManager;

    protected virtual void ApplyModifier()
    {

    }

    void Start()
    {
        ApplyModifier();
    }
}