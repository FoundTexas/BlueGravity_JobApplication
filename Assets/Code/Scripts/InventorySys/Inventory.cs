using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Inventory", menuName = "Inventory/Inventory")]
public class Inventory : ScriptableObject
{
    [SerializeField] private List<Item> items;

    public void AddItem(Item item)
    {
        items.Add(item);
    }

    public void RemoveItem(Item item)
    {
        items.Remove(item);
    }

    public bool ContainsItem(Item item)
    {
        return items.Contains(item);
    }

    public void UseItem(Item item)
    {
        // Add logic for using the item here
        Debug.Log("Using " + item.name);
    }

    public List<Item> GetItems()
    {
        return items;
    }

    public int GetItemCount()
    {
        return items.Count;
    }
}
