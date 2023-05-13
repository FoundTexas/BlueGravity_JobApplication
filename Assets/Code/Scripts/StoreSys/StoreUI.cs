using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StoreUI : MonoBehaviour
{
    static StoreUI inst;
    [SerializeField] private Canvas storeCanvas;
    [SerializeField] private GameObject storeItemPrefab;
    [SerializeField] private Transform storeItemParent;
    [SerializeField] private List<Item> itemsForSale;

    private void Start()
    {
        inst = this;
        storeCanvas.enabled = false;
    }

    public static void SetUI(List<Item> items)
    {
        inst.itemsForSale = items;

        foreach (Transform child in inst.storeItemParent)
        {
            Destroy(child.gameObject);
        }

        foreach (Item item in inst.itemsForSale)
        {
            GameObject storeItem = Instantiate(inst.storeItemPrefab, inst.storeItemParent);
            storeItem.GetComponent<StoreItemUI>().SetUI(item);
        }

        inst.storeCanvas.enabled = true;
    }
}
