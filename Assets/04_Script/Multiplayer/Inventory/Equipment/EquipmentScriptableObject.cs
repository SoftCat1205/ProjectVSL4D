using UnityEngine;

[CreateAssetMenu(fileName = "EquipmentScriptableObject", menuName = "ScriptableObjects/Passive Item", order = 0)]
public class EquipmentScriptableObject : ItemScriptableObject
{
    [SerializeField] private Equipment equipment;
    public Equipment Equipment => equipment;

    [SerializeField] private ItemCategory category;
    public ItemCategory Category => category;

    [SerializeField] private StatModifier[] modifiers;
    public StatModifier[] Modifiers => modifiers;

    [SerializeField] private int level;
    public int Level => level;

    [SerializeField] private EquipmentScriptableObject nextLevelEquipmentData;
    public EquipmentScriptableObject NextLevelEquipmentData { get => nextLevelEquipmentData; private set => nextLevelEquipmentData = value; }
}
