using System;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    [SerializeField] private ItemDatabase database;

    public event Action<InventoryManager> InventoryUpdate;

    private Dictionary<int, InventoryItem> inventoryItems = new(10)
    {
        {1, null},
        {2, null},
        {3, null},
        {4, null},
        {5, null},
        {6, null},
        {7, null},
        {8, null},
        {9, null},
        {10, null}
    };

    private void Awake()
    {
        database.Initialize();
    }

    public void AddItem(int id, int amount)
    {
        InventoryUpdate?.Invoke(this);

        foreach (KeyValuePair<int, InventoryItem> item in inventoryItems)
        {
            if (item.Value.ItemID == id)
            {
                inventoryItems[item.Key].Count += amount;
                return;
            }
        }

        foreach (KeyValuePair<int, InventoryItem> item in inventoryItems)
        {
            if (item.Value == null)
            {
                inventoryItems[item.Key].ItemID = id;
                inventoryItems[item.Key].Count += amount;
                return;
            }
        }
    }

    public void PlaceItem(int slot, InventoryItem item)
    {
        inventoryItems[slot] = item;
    }

    public int HasItem(int id)
    {
        foreach (KeyValuePair<int, InventoryItem> item in inventoryItems)
            if (item.Value.ItemID == id)
                return item.Key;

        return 0;
    }

    public InventoryItem GetSlotItem(int slot)
    {
        return inventoryItems[slot];
    }

    public ItemScriptableObject GetSlotData(int slot)
    {
        return database.GetItem(inventoryItems[slot].ItemID);
    }

    public bool RemoveItem(int id, int amount = 1)
    {
        foreach (KeyValuePair<int, InventoryItem> item in inventoryItems)
        {
            if (item.Value.ItemID == id)
            {
                inventoryItems[item.Key].Count -= amount;
                if (item.Value.Count <= 0)
                    inventoryItems[item.Key] = null;
                return true;
            }
        }

        return false;
    }

    public int RemoveItem(int slot)
    {
        if (slot < 1 || slot > 10)
            return 0;
        int ID = inventoryItems[slot].ItemID;
        inventoryItems[slot] = null;

        return ID;
    }
}