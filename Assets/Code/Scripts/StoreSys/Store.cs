using System.Collections.Generic;
using UnityEngine;

public class Store : MonoBehaviour
{
    [SerializeField] private Inventory inventory;
    [SerializeField] private float salePriceMultiplier = 1.2f;

    public void SellItem(Item item)
    {
        if (inventory.ContainsItem(item))
        {
            inventory.RemoveItem(item);
            float salePrice = item.Price * salePriceMultiplier;
            // Add logic for selling the item here
            Debug.Log("Sold " + item.name + " for " + salePrice);
        }
        else
        {
            Debug.LogWarning("Item not found in inventory!");
        }
    }

    public void BuyItem(Item item)
    {
        // Add logic for buying the item from the player here
        Debug.Log("Bought " + item.name + " from player");
        inventory.AddItem(item);
    }

    void SetStoreUI() => StoreUI.SetUI(inventory.GetItems());
}
