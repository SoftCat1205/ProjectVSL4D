using System.Collections.Generic;
using UnityEngine;

public class ItemDatabase : MonoBehaviour
{
    [SerializeField] private List<ItemScriptableObject> itemList;
    [SerializeField] private Dictionary<int, ItemScriptableObject> database;

    private void Start()
    {
        database = new Dictionary<int, ItemScriptableObject>();

        foreach (ItemScriptableObject item in itemList)
        {
            database.Add(item.ItemID, item);
        }
    }

    public ItemScriptableObject GetItem(int itemID)
    {
        return database[itemID];
    }
}