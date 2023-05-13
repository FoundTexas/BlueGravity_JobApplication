using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StoreUI : MonoBehaviour
{
    static StoreUI inst;
    GameObject storeCanvas;
    GameObject storeItemUI;
    Transform content;
    List<Item> itemsForSale;
    Store store;

    private void Start()
    {
        inst = this;
        storeItemUI = Resources.Load<GameObject>("Prefabs/StoreItemUI");
        storeCanvas = transform.Find("StoreCanvas").gameObject;
        content = storeCanvas.transform.Find("Scroll View").GetChild(0).GetChild(0);
        storeCanvas.SetActive(false);

        RefreshScreen();
    }

    void RefreshScreen()
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

            inst.RefreshScreen();

            foreach (Item item in inst.itemsForSale)
            {
                GameObject storeItem = Instantiate(inst.storeItemUI, Vector3.zero, Quaternion.identity, inst.content);
                storeItem.GetComponent<StoreItemUI>().SetUI(item , store);
            }
        }

        inst.storeCanvas.SetActive(active);
    }
}
