using System.Collections.Generic;
using UnityEngine;

public class Store : MonoBehaviour
{
    [SerializeField] private Inventory inventory;
    [SerializeField] private float saleMultiplier = 1.2f;

    Player player;

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
            player.Inventory.AddItem(item);
        }
        else
        {
            Debug.LogWarning("Item not found in inventory!");
        }
    }

    public void BuyItem(Item item)
    {
        inventory.AddItem(item);
    }

    void SetStoreUI(bool value) => StoreUI.SetUI(inventory.GetItems(), this, value);

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && other.TryGetComponent<Player>(out player))
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
