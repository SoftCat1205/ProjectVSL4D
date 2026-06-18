using UnityEngine;

[CreateAssetMenu(fileName = "EquipmentScriptableObject", menuName = "ScriptableObjects/Passive Item", order = 0)]
public class EquipmentScriptableObject : ScriptableObject
{
    [SerializeField] private float multiplier;
    public float Multiplier { get => multiplier; private set => multiplier = value; }

    [SerializeField] private float additive;
    public float Additive { get => additive; private set => additive = value; }

    [SerializeField] private int level;
    public int Level { get => level; private set => level = value; }

    [SerializeField] private GameObject nextLevelPrefab;
    public GameObject NextLevelPrefab { get => nextLevelPrefab; private set => nextLevelPrefab = value; }

    [SerializeField] private string displayName;
    public string DisplayName { get => displayName; private set => displayName = value; }

    [SerializeField] private string discription;
    public string Discription { get => discription; private set => discription = value; }

    [SerializeField] private Sprite icon;
    public Sprite Icon { get => icon; private set => icon = value; }
}
