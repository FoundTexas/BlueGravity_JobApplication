using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class WoredrobeItemUI : MonoBehaviour
{
    public void SetUI(Item item)
    {
        GetComponentInChildren<TextMeshProUGUI>().text = item.name;

        GetComponent<Button>().onClick.AddListener(() => EquipItem(item));
        GetComponent<Button>().onClick.AddListener(DestroyButton);
    }

    void DestroyButton() => Destroy(this.gameObject);
    void EquipItem(Item item) => Woredrobe.EquipItem(item);
}
