using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Item properties for dropping when an object is destroyed
[System.Serializable]
public class ItemDrop
{
    public Item item;
    public int minDrop;
    public int maxDrop;
    // Change that the item will drop
    [Range(0f, 100f)]
    public float dropChance;
}
