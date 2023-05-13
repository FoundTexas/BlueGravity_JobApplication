using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class StoreItemUI : MonoBehaviour
{
    TextMeshProUGUI itemPrice, itemName;
    Button actionButton;
    Image itemImage;
    Item item;

    private void Awake() {
        itemPrice = transform.Find("ItemPrice").GetComponent<TextMeshProUGUI>();
        itemName = transform.Find("ItemName").GetComponent<TextMeshProUGUI>();
        actionButton = transform.Find("ActionButton").GetComponent<Button>();
        itemImage = transform.Find("ItemSpriteFrame").GetComponent<Image>();
    }

    public void SetUI(Item item, bool sell = true)
    {
        this.item = item;
        itemName.text = item.ID;
        itemPrice.text = item.Price.ToString();

        actionButton.onClick.AddListener((sell ? SellItem : BuyItem));
        actionButton.GetComponentInChildren<TextMeshProUGUI>().text = sell ? "Sell" : "Buy";
    }

    private void BuyItem()
    {
        // Do something when the buy button is clicked, like adding the item to the player's inventory
    }
    private void SellItem()
    {
        // Do something when the buy button is clicked, like adding the item to the player's inventory
    }
}
