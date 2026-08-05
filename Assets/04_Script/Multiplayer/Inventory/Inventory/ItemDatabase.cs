using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemDatabase", menuName = "Items/Database")]
public class ItemDatabase : ScriptableObject
{
    public List<ItemScriptableObject> Items;

    private Dictionary<int, ItemScriptableObject> itemDictionary;


    public void Initialize()
    {
        itemDictionary = new Dictionary<int, ItemScriptableObject>();

        foreach (ItemScriptableObject item in Items)
        {
            if (itemDictionary.ContainsKey(item.ItemID))
            {
                Debug.LogError($"Duplicate Item ID: {item.ItemID}");
                continue;
            }

            itemDictionary.Add(item.ItemID, item);
        }
    }


    public ItemScriptableObject GetItem(int id)
    {
        if (itemDictionary.TryGetValue(id, out ItemScriptableObject item))
        {
            return item;
        }

        Debug.LogError($"Item ID {id} does not exist");
        return null;
    }
}