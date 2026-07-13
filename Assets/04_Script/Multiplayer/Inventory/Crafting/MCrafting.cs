using UnityEngine;

public class MCrafting : MonoBehaviour
{
    public bool CanCrafft(RecipeScriptableObejct recipe, MInventory inventory)
    {
        foreach (InventoryItem requirements in recipe.Requirements)
        {
            if (!inventory.HasItem(requirements.ItemID, requirements.Amount))
                return false;
        }
        return true;
    }
}