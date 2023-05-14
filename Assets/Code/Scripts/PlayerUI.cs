using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerUI : MonoBehaviour
{
    static PlayerUI inst;
    TextMeshProUGUI money;

    public static TextMeshProUGUI Money
    {
        get{ return inst.money;}
        set{inst.money = value;}
    }

    private void Awake() {
        inst = this;
    }

    private void Start() {
        money = transform.Find("PlayerMoney").GetComponent<TextMeshProUGUI>();
        money.text = Player.Inventory.Money + "$";
    }
}
