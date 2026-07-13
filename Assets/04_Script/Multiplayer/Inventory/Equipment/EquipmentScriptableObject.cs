using UnityEngine;

[CreateAssetMenu(fileName = "EquipmentScriptableObject", menuName = "ScriptableObjects/Passive Item", order = 0)]
public class EquipmentScriptableObject : ScriptableObject
{
    [SerializeField] private EquipmentCategory category;
    public EquipmentCategory Category => category;

    [SerializeField] private float multiplier;
    public float Multiplier { get => multiplier; private set => multiplier = value; }

    [SerializeField] private float additive;
    public float Additive { get => additive; private set => additive = value; }

    [SerializeField] private float cooldown;
    public float Cooldown => cooldown;

    [SerializeField] private int level;
    public int Level { get => level; private set => level = value; }

    [SerializeField] private EquipmentScriptableObject nextLevelEquipmentData;
    public EquipmentScriptableObject NextLevelEquipmentData { get => nextLevelEquipmentData; private set => nextLevelEquipmentData = value; }
}
