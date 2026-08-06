using UnityEngine;

public class MCrafting : MonoBehaviour
{
    public bool CanCrafft(RecipeScriptableObejct recipe, InventoryManager inventory)
    {
        foreach (InventoryItem requirements in recipe.Requirements)
        {
            if (inventory.HasItem(requirements.ItemID) != 0)
                return false;
        }
        return true;
    }
}