using System.IO;
using UnityEditor;
using UnityEngine;
public enum ClothTarget
{
    HEAD, TORSO, none
}

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item")]
public class Item : ScriptableObject
{
    [SerializeField] float price;
    [SerializeField] string id;
    [SerializeField] Material texture;
    [SerializeField] ClothTarget target;
    [SerializeField] Sprite icon;

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

    public Sprite Icon
    {
        get
        {
            if (!icon)
                icon = Resources.Load<Sprite>("GeneratedSprites/" + name);

            Debug.Log(icon);

            return icon;
        }
        private set { icon = value; }
    }

    public GameObject GetItemPrefab()
    {
        GameObject g = Resources.Load<GameObject>("Prefabs/" + id);
        g.GetComponent<Renderer>().material = texture;
        return g;
    }

    Sprite LoadDefaultIcon()
    {

        GameObject loadedObject = Resources.Load<GameObject>("Prefabs/" + id);

        // Assign the new material to the Renderer
        Renderer renderer = loadedObject.GetComponent<Renderer>();
        if (renderer != null)
        {
            renderer.material = texture;
            //AssetDatabase.Refresh();
        }

        // Get the updated thumbnail image
        //Texture2D thumbnail = AssetPreview.GetAssetPreview(loadedObject);

        //Sprite newSprite = Sprite.Create(thumbnail, new Rect(0, 0, thumbnail.width, thumbnail.height), new Vector2(0.5f, 0.5f));


        // Encode the texture as PNG
        //byte[] bytes = thumbnail.EncodeToPNG();

        // Create a new file in the Resources folder with a unique filename
        string fileName = name + ".png";
        string filePath = Application.dataPath + "/Resources/GeneratedSprites/" + fileName;
        //File.WriteAllBytes(filePath, bytes);

        //string path = "Assets/Art/GeneratedSprites/" + name + ".asset";


        Sprite tmp = Resources.Load<Sprite>("GeneratedSprites/" + name);

        Debug.Log(tmp != null);

        return tmp;
    }
}
