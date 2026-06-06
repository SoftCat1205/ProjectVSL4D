using UnityEngine;

public class PassiveItem : MonoBehaviour
{
    protected PlayerStats ps;
    public PassiveItemScriptableObject passiveItemData;

    protected virtual void ApplyModifier()
    {
        //Applies the values in the child classes
    }

    void Start()
    {
        ps = PlayerStats.Instance;
        ApplyModifier();
    }
}
