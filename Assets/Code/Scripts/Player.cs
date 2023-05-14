using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player inst;

    [SerializeField] Inventory inventory, clothing;
    [SerializeField] Transform HEAD, TORSO;

    private void Awake() {
        inst = this;
    }

    private void Start() {
        UpdateOutfit();
    }

    void RefreshOutfit(Transform parent)
    {
        foreach (Transform child in parent)
        {
            Destroy(child.gameObject);
        }
    }

    public static void UpdateOutfit()
    {
        inst.RefreshOutfit(inst.HEAD);
        inst.RefreshOutfit(inst.TORSO);

        Item h = inst.clothing.GetItems().Find(x => x.Target == ClothTarget.HEAD);
        Item t = inst.clothing.GetItems().Find(x => x.Target == ClothTarget.TORSO);

        if(h)
            Instantiate(h.GetItemPrefab(), inst.HEAD.position, Quaternion.identity,  inst.HEAD);

        if(t)
            Instantiate(t.GetItemPrefab(), inst.TORSO.position, Quaternion.identity,  inst.TORSO);
    }

    public static Inventory Inventory
    {
        get { return inst.inventory; }
        private set { inst.inventory = value; }
    }

    public static Inventory Clothing
    {
        get { return inst.clothing; }
        private set { inst.clothing = value; }
    }
}
