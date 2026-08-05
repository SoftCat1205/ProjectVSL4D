using UnityEngine;

public class MInventoryUI : MonoBehaviour
{
    private MInventory _inventory;

    public void Initialize(MInventory inventory)
    {
        _inventory = inventory;

        _inventory.InventoryUpdate += Refresh;

        Refresh();
    }

    private void Refresh()
    {

    }
}