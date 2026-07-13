using System.Collections.Generic;
using UnityEngine;

public class RecipeScriptableObejct : ScriptableObject
{
    [SerializeField] private ItemScriptableObject result;
    public ItemScriptableObject Result => result;

    [SerializeField] private List<InventoryItem> requirements;
    public List<InventoryItem> Requirements;
}