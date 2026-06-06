using UnityEngine;

[CreateAssetMenu(fileName = "PassiveItemScriptableObject", menuName = "ScriptableObjects/Passive Item", order = 0)]
public class PassiveItemScriptableObject : ScriptableObject
{
    [SerializeField] float multiplier;
    public float Multiplier { get => multiplier; private set => multiplier = value; }

    [SerializeField] float additive;
    public float Additive { get => additive; private set => additive = value; }

    [SerializeField] int level;
    public int Level { get => level; private set => level = value; }

    [SerializeField] GameObject nextLevelPrefab;
    public GameObject NextLevelPrefab { get => nextLevelPrefab; private set => nextLevelPrefab = value; }

    [SerializeField] Sprite icon;
    public Sprite Icon { get => icon; private set => icon = value; }
}
