using UnityEngine;

[CreateAssetMenu(fileName = "PassiveItemScriptableObject", menuName = "ScriptableObjects/Passive Item", order = 0)]
public class PassiveItemScriptableObject : ScriptableObject
{
    [SerializeField] float multiplier;
    public float Multiplier { get => multiplier; private set => multiplier = value; }

    [SerializeField] float additive;
    public float Additive { get => additive; private set => additive = value; }
}
