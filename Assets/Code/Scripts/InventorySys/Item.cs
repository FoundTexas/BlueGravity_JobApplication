using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item")]
public class Item : ScriptableObject
{
    [SerializeField] private float price;
    [SerializeField] private string  id;

    public Item(float price, string id)
    {
        this.price = price;
        this.id = id;
    }

    public Item()
    {
        price = 0;
        ID = "DefaultObj";
    }

    public float Price
    {
        get { return price; }
        set { price = value; }
    }
    public string ID
    {
        get { return id; }
        set { id = value; }
    }

    public GameObject GetItemPrefab()
    {
        return Resources.Load<GameObject>("Prefabs/" + id);
    }
}
