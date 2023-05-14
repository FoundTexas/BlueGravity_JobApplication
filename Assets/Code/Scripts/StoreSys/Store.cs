using System.Collections.Generic;
using UnityEngine;

public class Store : MonoBehaviour
{
    [SerializeField] private Inventory inventory;
    [SerializeField] private float saleMultiplier = 1.2f, buyMultiplier = 0.2f;

    public float Multiplier
    {
        get { return saleMultiplier; }
        private set { saleMultiplier = value; }
    }
    public float ButMult
    {
        get { return buyMultiplier; }
        private set { buyMultiplier = value; }
    }

    public Inventory Inventory
    {
        get { return inventory; }
        private set { inventory = value; }
    }


    public bool SellItem(Item item)
    {
        if (inventory.ContainsItem(item) && (item.Price * Multiplier <= Player.Inventory.Money))
        {
            inventory.Money += item.Price * Multiplier;
            Player.Inventory.Money -= item.Price * Multiplier;

            inventory.RemoveItem(item);
            Player.Inventory.AddItem(item);
            UpdateTexts();
            return true;
        }
        else
        {
            Debug.LogWarning("Item not found in inventory!");
            return false;
        }
    }

    public bool BuyItem(Item item)
    {
        if (item.Price * buyMultiplier <= inventory.Money)
        {
            inventory.Money -= item.Price * buyMultiplier;
            Player.Inventory.Money += item.Price * buyMultiplier;

            Player.Inventory.RemoveItem(item);
            inventory.AddItem(item);
            UpdateTexts();
            return true;
        }

        return false;
    }

    void UpdateTexts()
    {
        StoreUI.StoreText.text = "STORE " + Inventory.Money + "$";
        PlayerUI.Money.text = Player.Inventory.Money + "$";
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

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Player" && Player.inst.gameObject == other.gameObject && !Woredrobe.OnWardrobe())
        {
            SetStoreUI(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if (other.gameObject.CompareTag("Player"))
        {
            SetStoreUI(false);
        }
    }
}
