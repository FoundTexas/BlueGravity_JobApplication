using System.Collections.Generic;
using UnityEngine;

public class Store : MonoBehaviour
{
    [SerializeField] private Inventory inventory;
    [SerializeField] private float saleMultiplier = 1.2f;

    public float Multiplier
    {
        get { return saleMultiplier; }
        private set { saleMultiplier = value; }
    }

    public void SellItem(Item item)
    {
        if (inventory.ContainsItem(item))
        {
            inventory.RemoveItem(item);
            Player.Inventory.AddItem(item);
        }
        else
        {
            Debug.LogWarning("Item not found in inventory!");
        }
    }

    public void BuyItem(Item item)
    {
        Player.Inventory.RemoveItem(item);
        inventory.AddItem(item);
    }

    void SetStoreUI(bool value) => StoreUI.SetUI(inventory.GetItems(), this, value);

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && Player.inst.gameObject == other.gameObject && !Woredrobe.OnWardrobe())
        {
            SetStoreUI(true);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            SetStoreUI(false);
        }
    }
}
