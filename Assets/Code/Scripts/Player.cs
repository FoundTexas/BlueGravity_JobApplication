using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] Inventory inventory;

    public Inventory Inventory
    {
        get { return inventory; }
        private set { inventory = value; }
    }
}
