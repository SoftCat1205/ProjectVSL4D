using UnityEngine;

[CreateAssetMenu(fileName = "EquipmentScriptableObject", menuName = "ScriptableObjects/Passive Item", order = 0)]
public class EquipmentScriptableObject : ScriptableObject
{
    [SerializeField] private EquipmentCategory category;
    public EquipmentCategory Category => category;

    [SerializeField] private StatModifier[] modifiers;
    public StatModifier[] Modifiers => modifiers;

    [SerializeField] private EquipmentScriptableObject nextLevelEquipmentData;
    public EquipmentScriptableObject NextLevelEquipmentData { get => nextLevelEquipmentData; private set => nextLevelEquipmentData = value; }
}
