using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class WoredrobeItemUI : MonoBehaviour
{
    public void SetUI(Item item)
    {
        if (item.ID.Equals("NULL") && item.Price < 0)
        {
            GetComponentInChildren<TextMeshProUGUI>().text = "";
        }
        else
        {
            GetComponentInChildren<TextMeshProUGUI>().text = item.name;
            transform.Find("Image").GetComponent<Image>().sprite = item.Icon;
            GetComponent<Button>().onClick.AddListener(DestroyButton);
        }


        GetComponent<Button>().onClick.AddListener(() => EquipItem(item));
    }

    void DestroyButton() => Destroy(this.gameObject);
    void EquipItem(Item item) => Woredrobe.EquipItem(item);
}
