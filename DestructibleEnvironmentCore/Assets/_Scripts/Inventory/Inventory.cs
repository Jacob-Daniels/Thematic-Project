using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Inventory stores all the items the player is holding
public class Inventory : MonoBehaviour
{
    public static Inventory instance;

    [Header("Inventory Properties:")]
    [SerializeField] private List<InventoryItem> inventoryItems = new List<InventoryItem>();
    
    private void Awake()
    {
        // Singleton
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void AddItem(Item _newItem, int _value)
    {
        if (_value < 0) { return; }
        // Add item to inventory 
        InventoryItem listItem = SearchListForItem(_newItem);
        if (listItem != null)
        {
            // Add the total value onto the stack
            listItem.AddToStack(_value);
        }
        else
        {
            // Create new item and ui container
            InventoryItem createdItem = new InventoryItem(_newItem, _value, UIManager.instance.CreateInventoryContainer());
            createdItem.UpdateContainer();
            inventoryItems.Add(createdItem);
        }
    }

    public void RemoveItem(Item _newItem, int _value)
    {
        // Remove item from the list
        InventoryItem listItem = SearchListForItem(_newItem);
        if (listItem != null)
        {
            // Remove from stack if possible (above 0)
            if (listItem.stack - _value >= 1)
            {
                listItem.RemoveFromStack(_value);
            }
            else if (listItem.stack - _value == 0)
            {
                // Destroy ui container and remove from list
                Destroy(listItem.uiContainer);
                inventoryItems.Remove(listItem);
            }
        }
    }

    private InventoryItem SearchListForItem(Item _newItem)
    {
        // Search the inventory list for an item and return it
        foreach (InventoryItem inventItem in inventoryItems)
        {
            if (inventItem.item == _newItem) { return inventItem; }
        }
        return null;
    }

    public bool CanRemoveItem(Item _item, int _value)
    {
        // Get item from inventory list
        InventoryItem listItem = SearchListForItem(_item);
        if (listItem == null) { return false; }
        // Return true if value can be deducted from inventory items
        return listItem.stack - _value >= 0 ? true : false;
    }
}
