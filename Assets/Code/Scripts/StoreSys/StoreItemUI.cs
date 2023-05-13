using UnityEngine;
using UnityEngine.UI;

public class StoreItemUI : MonoBehaviour
{
    [SerializeField] private Text itemNameText;
    [SerializeField] private Text itemPriceText;
    [SerializeField] private Button buyButton;
    [SerializeField] private Item item;

    private void Start()
    {
        buyButton.onClick.AddListener(BuyItem);
    }

    public void SetUI(Item item)
    {
        this.item = item;
        itemNameText.text = item.ID;
        itemPriceText.text = item.Price.ToString();
    }

    private void BuyItem()
    {
        // Do something when the buy button is clicked, like adding the item to the player's inventory
    }
}
