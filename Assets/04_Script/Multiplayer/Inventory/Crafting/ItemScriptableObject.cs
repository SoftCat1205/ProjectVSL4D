using UnityEngine;

public class ItemScriptableObject : ScriptableObject
{
    [SerializeField] private int itemID;
    public int ItemID => itemID;

    [SerializeField] private string itemName;
    public string ItemName => itemName;

    [SerializeField] private Sprite icon;
    public Sprite Icon => icon;

    [SerializeField] private int maxStack;
    public int MaxStack => maxStack;
}