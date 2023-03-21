using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    private Dictionary<Item, InventoryItem> itemDictionary; //tracks what items player has (if 0 amount, will not be found here)
    public List<InventoryItem> inventory { get; private set; }

    private void Awake()
    {
        inventory = new List<InventoryItem>();
        itemDictionary = new Dictionary<Item, InventoryItem>();
    }

    public void Add(Item refData)
    {
        if (itemDictionary.TryGetValue(refData, out InventoryItem value)) //search dictionary for item, if found return it
        {
            value.AddToStack();
        }
        else //if not found, add to dictionary and inventory
        {
            InventoryItem newItem = new InventoryItem(refData);
            inventory.Add(newItem);
            itemDictionary.Add(refData, newItem);
        }
    }
    public void Remove(Item refData)
    {
        if (itemDictionary.TryGetValue(refData, out InventoryItem value)) //search dictionary for item, if found return it
        {
            value.RemoveFromStack();
            
            if (value.stackSize == 0) //if number of items hits 0, remove from inventory
            {
                inventory.Remove(value);
                itemDictionary.Remove(refData);
            }
        }
    }
}

[Serializable]
public class InventoryItem
{
    public Item data { get; private set;}
    public int stackSize { get; private set;} // counts how many of each item there are

    public InventoryItem(Item source)
    {
        data = source;
        AddToStack();
    }

    public void AddToStack()
    {
        stackSize++;
    }
    
    public void RemoveFromStack()
    {
        stackSize--;
    }
}