using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class StoreItemUI : MonoBehaviour
{
    public TextMeshProUGUI itemPrice, itemName;
    Button actionButton;
    Image itemImage;
    Item item;
    Store store;

    public void SetUI(Item item, Store store, bool sell = true)
    {
        this.item = item;
        this.store = store;
        itemName = transform.Find("ItemName").GetComponent<TextMeshProUGUI>();
        itemName.text = item.name;
        itemPrice = transform.Find("ItemPrice").GetComponent<TextMeshProUGUI>();
        itemPrice.text = (item.Price * (sell ? store.Multiplier : 0.6f) ).ToString();

        actionButton = transform.Find("ActionButton").GetComponent<Button>();
        actionButton.onClick.AddListener((sell ? SellItem : BuyItem));
        actionButton.onClick.AddListener(DestroyButton);

        actionButton.GetComponentInChildren<TextMeshProUGUI>().text = sell ? "Buy" : "Sell";

        itemImage = transform.Find("ItemSpriteFrame").GetComponent<Image>();
    }

    void DestroyButton() => Destroy(this.gameObject);
    void BuyItem() => store.BuyItem(item);
    void SellItem() => store.SellItem(item);
}
