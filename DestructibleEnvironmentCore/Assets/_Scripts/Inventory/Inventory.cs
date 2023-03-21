using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [Header("Inventory Properties:")]
    [SerializeField] private List<InventoryItem> inventoryItems = new List<InventoryItem>();


    #region TEMP CODE
    [SerializeField] private Item testItem;

    private void Update()
    {
        // TEMPORARY CODE TO ADD AND REMOVE ITEMS FROM THE INVENTORY (REMOVE ONCE SETUP)
        if (Input.GetKeyDown(KeyCode.Alpha8))
        {
            AddItem(testItem);
        } else if (Input.GetKeyDown(KeyCode.Alpha9))
        {
            RemoveItem(testItem);
        }
    }
    #endregion

    public void AddItem(Item _newItem)
    {
        // Add item to inventory 
        InventoryItem listItem = SearchListForItem(_newItem);
        if (listItem != null)
        {
            listItem.stack++;
        }
        else
        {
            inventoryItems.Add(new InventoryItem(_newItem));
        }
    }

    public void RemoveItem(Item _newItem)
    {
        // Remove item from the list
        InventoryItem listItem = SearchListForItem(_newItem);
        if (listItem != null)
        {
            if (listItem.stack > 1)
            {
                listItem.stack--;
            }
            else
            {
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
}
