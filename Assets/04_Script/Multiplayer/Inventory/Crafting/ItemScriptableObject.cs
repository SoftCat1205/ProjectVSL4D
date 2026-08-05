using System.Collections.Generic;
using UnityEngine;

public class ItemScriptableObject : ScriptableObject
{
    [SerializeField] private int itemID;
    public int ItemID => itemID;

    [SerializeField] private string itemName;
    public string ItemName => itemName;

    [SerializeField] private ItemType type;
    public ItemType Type => type;

    [SerializeField] private List<ItemCategory> allowedSlots;
    public List<ItemCategory> AllowedSlots => allowedSlots;

    [SerializeField] private Sprite icon;
    public Sprite Icon => icon;

    [SerializeField] private int maxStack;
    public int MaxStack => maxStack;
}

public enum ItemType
{
    Material,
    Weapon,
    Equipment
}