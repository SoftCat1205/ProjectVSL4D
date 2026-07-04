using UnityEngine;

public class Equipment : MonoBehaviour
{
    public EquipmentScriptableObject EquipmentData;
    public EquipmentCalculator EquipmentCalculator;

    protected virtual void ApplyModifier()
    {

    }

    void Start()
    {
        ApplyModifier();
    }
}