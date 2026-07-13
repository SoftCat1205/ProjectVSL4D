using System.Collections.Generic;
using UnityEngine;

public class MInventory : MonoBehaviour
{
    private List<InventoryItem> items = new();

    public void AddItem(int id, int amount)
    {
        for (int i = 0; i < items.Count; i++)
        {
            if (items[i].ItemID == id)
            {
                InventoryItem item = items[i];
                item.Amount += amount;
                items[i] = item;
                return;
            }
        }

        items.Add(new InventoryItem { ItemID = id, Amount = amount });
    }

    public bool HasItem(int id, int amount = 1)
    {
        foreach (InventoryItem item in items)
            if (item.ItemID == id)
                return item.Amount >= amount;

        return false;
    }

    public bool RemoveItem(int id, int amount)
    {
        for (int i = 0; i < items.Count; i++)
        {
            if (items[i].ItemID == id)
            {
                InventoryItem item = items[i];

                if (item.Amount < amount)
                    return false;

                item.Amount -= amount;

                if (item.Amount <= 0)
                {
                    items.RemoveAt(i);
                }
                else
                {
                    items[i] = item;
                }

                return true;
            }
        }
        return false;
    }
}