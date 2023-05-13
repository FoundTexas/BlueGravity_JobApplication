using UnityEngine;
public enum ClothTarget
{
    HEAD,TORSO, none
}

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item")]
public class Item : ScriptableObject
{
    [SerializeField] private float price;
    [SerializeField] private string  id;
    [SerializeField] private Material texture;
    [SerializeField] private ClothTarget target;

    public Item(float price, string id, ClothTarget target)
    {
        this.price = price;
        this.id = id;
        this.target = target;
    }

    public Item()
    {
        price = 0;
        ID = "DefaultObj";
        this.target = ClothTarget.none;
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
    public ClothTarget Target
    {
        get { return target; }
        private set { target = value; }
    }

    public GameObject GetItemPrefab()
    {
        GameObject g = Resources.Load<GameObject>("Prefabs/" + id);
        g.GetComponent<Renderer>().material = texture;
        return g;
    }
}
