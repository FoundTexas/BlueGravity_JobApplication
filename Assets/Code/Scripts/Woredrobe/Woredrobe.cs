using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using System.Linq;

public class Woredrobe : MonoBehaviour
{
    static Woredrobe inst;
    GameObject outfitCamera, topDownCamera;
    bool useFreeLookCamera = false; // Whether to use the free look camera by default

    GameObject woredrobe;
    GameObject woredrobeItemUI;
    Transform headitems, torsoitems;

    public static bool OnWardrobe() => inst.useFreeLookCamera;

    private void Awake()
    {
        inst = this;
    }

    private void Start()
    {
        woredrobeItemUI = Resources.Load<GameObject>("Prefabs/WoredrobeItemUI");
        Transform tempT = GameObject.Find("Cameras").transform;
        outfitCamera = tempT.Find("OutFitView").gameObject;
        topDownCamera = tempT.Find("TopDownView").gameObject;

        woredrobe = transform.Find("woredrobe").gameObject;

        headitems = woredrobe.transform.Find("HEAD").Find("Scroll View").GetChild(0).GetChild(0);
        torsoitems = woredrobe.transform.Find("TORSO").Find("Scroll View").GetChild(0).GetChild(0);


        if (useFreeLookCamera)
        {
            ActivateFreeLookCamera();
        }
        else
        {
            ActivateVirtualCamera();
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !StoreUI.OnStore())
        {
            Debug.Log("Entered with: " + StoreUI.OnStore());
            if (useFreeLookCamera)
            {
                ActivateVirtualCamera();
            }
            else
            {
                ActivateFreeLookCamera();
            }
        }
    }

    void RefreshScreen(Transform parent)
    {
        foreach (Transform child in parent)
        {
            Destroy(child.gameObject);
        }
    }

    void PopulateScreen(Transform parent, List<Item> items)
    {
        GameObject storeItem = Instantiate(woredrobeItemUI, Vector3.zero, Quaternion.identity, parent);
        storeItem.GetComponent<WoredrobeItemUI>().SetUI(
        new Item(-10, "NULL", parent == headitems ? ClothTarget.HEAD : ClothTarget.TORSO));

        foreach (Item item in items)
        {
            storeItem = Instantiate(woredrobeItemUI, Vector3.zero, Quaternion.identity, parent);
            storeItem.GetComponent<WoredrobeItemUI>().SetUI(item);
        }
    }

    void RefreshAll()
    {
        RefreshScreen(headitems);
        RefreshScreen(torsoitems);

        List<Item> tmpTorso = Player.Inventory.GetItems().FindAll(x => x.Target == ClothTarget.TORSO);
        List<Item> tmpHead = Player.Inventory.GetItems().FindAll(x => x.Target == ClothTarget.HEAD);

        PopulateScreen(torsoitems, tmpTorso);
        PopulateScreen(headitems, tmpHead);
    }

    private void ActivateFreeLookCamera()
    {
        if(StoreUI.OnStore())
        {
            Debug.LogError("Entering on store active");
        }
        RefreshAll();

        outfitCamera.gameObject.SetActive(true);
        topDownCamera.gameObject.SetActive(false);
        useFreeLookCamera = true;
        woredrobe.SetActive(true);
    }

    void ActivateVirtualCamera()
    {
        outfitCamera.gameObject.SetActive(false);
        topDownCamera.gameObject.SetActive(true);
        useFreeLookCamera = false;
        woredrobe.SetActive(false);
    }

    public static void EquipItem(Item item)
    {
        if (item.ID.Equals("NULL") && item.Price < 0)
        {
            Item prev = Player.Clothing.GetItems().Find(x => x.Target == item.Target);

            if (prev)
            {
                Player.Clothing.RemoveItem(prev);
                Player.Inventory.AddItem(prev);
            }
        }
        else
        {
            List<Item> prev = Player.Clothing.GetItems().FindAll(x => x.Target == item.Target);

            Player.Inventory.RemoveItem(item);
            foreach (Item i in prev)
            {
                Player.Clothing.RemoveItem(i);
                Player.Inventory.AddItem(i);
            }
            Player.Clothing.AddItem(item);
        }

        inst.RefreshAll();

        Player.UpdateOutfit();
    }

}

