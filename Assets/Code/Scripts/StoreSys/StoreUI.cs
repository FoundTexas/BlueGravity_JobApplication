using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StoreUI : MonoBehaviour
{
    static StoreUI inst;
    GameObject storeCanvas;
    GameObject storeItemUI;
    Transform sellcontent, buycontent;
    Button sell, buy;
    List<Item> itemsForSale;
    Store store;

    public static bool OnStore() => inst.storeCanvas.activeInHierarchy;

    private void Start()
    {
        inst = this;
        storeItemUI = Resources.Load<GameObject>("Prefabs/StoreItemUI");
        storeCanvas = transform.Find("StoreCanvas").gameObject;
        sellcontent = storeCanvas.transform.Find("Sell Scroll View").GetChild(0).GetChild(0);
        buycontent = storeCanvas.transform.Find("Buy Scroll View").GetChild(0).GetChild(0);

        sell = storeCanvas.transform.Find("Sell Button").GetComponent<Button>();
        sell.onClick.AddListener(() => RePopulateScreen(sellcontent));
        buy = storeCanvas.transform.Find("Buy Button").GetComponent<Button>();
        buy.onClick.AddListener(() => RePopulateScreen(buycontent));


        storeCanvas.SetActive(false);

        RefreshScreen(sellcontent);
        RefreshScreen(buycontent);
    }

    void RePopulateScreen(Transform content)
    {
        RefreshScreen(content);

        foreach (Item item in (content == buycontent) ? itemsForSale : Player.Inventory.GetItems())
        {
            GameObject storeItem = Instantiate(inst.storeItemUI, Vector3.zero, Quaternion.identity, content);
            storeItem.GetComponent<StoreItemUI>().SetUI(item, store, (content == buycontent));
        }
    }

    void RefreshScreen(Transform content)
    {
        foreach (Transform child in content)
        {
            Destroy(child.gameObject);
        }
    }

    public static void SetUI(List<Item> items, Store store, bool active)
    {
        if (active)
        {
            inst.store = store;
            inst.itemsForSale = items;

            inst.RePopulateScreen(inst.sellcontent);
            inst.RePopulateScreen(inst.buycontent);
        }

        inst.storeCanvas.SetActive(active);
    }
}
