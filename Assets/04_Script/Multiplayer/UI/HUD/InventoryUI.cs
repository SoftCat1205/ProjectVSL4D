using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    [SerializeField] private InventoryUISlot[] slots;

    private InventoryManager _inventory;

    public void Initialize(InventoryManager inventory)
    {
        _inventory = inventory;

        _inventory.InventoryUpdate += Refresh;

        Refresh(inventory);
    }

    private void Refresh(InventoryManager inventory)
    {
        for (int i = 0; i < 10; i++)
        {
            slots[i].Display(inventory.GetSlotItem(i), inventory.GetSlotData(i));
        }
    }
}