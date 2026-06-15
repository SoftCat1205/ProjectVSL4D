using UnityEngine;

public class PassiveItem : MonoBehaviour
{
    public PassiveItemScriptableObject PassiveItemData;
    public Player player;

    protected virtual void ApplyModifier()
    {
        //Applies the values in the child classes
    }

    void Start()
    {
        ApplyModifier();
    }
}
