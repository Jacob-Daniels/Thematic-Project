using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class InventoryItem
{
    public Item item;
    public int stack;

    public InventoryItem(Item item)
    {
        this.item = item;
        this.stack = 1;
    }
}
