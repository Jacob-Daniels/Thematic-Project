using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Inventory stores all the items the player is holding
public class Inventory : MonoBehaviour
{
    public static Inventory instance;

    [Header("Inventory Properties:")]
    [SerializeField] private List<InventoryItem> inventoryItems = new List<InventoryItem>();

    #region TEMP CODE
    [SerializeField] private Item testItem;

    private void Awake()
    {
        // Singleton
        if (instance == null)
        {
            instance = this;
        } else
        {
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        // TEMPORARY CODE TO ADD AND REMOVE ITEMS FROM THE INVENTORY (REMOVE ONCE SETUP)
        if (Input.GetKeyDown(KeyCode.Alpha9))
        {
            AddItem(testItem, 1);
        } else if (Input.GetKeyDown(KeyCode.Alpha8))
        {
            RemoveItem(testItem);
        }
    }
    #endregion

    public void AddItem(Item _newItem, int _value)
    {
        if (_value < 0) { return; }
        // Add item to inventory 
        InventoryItem listItem = SearchListForItem(_newItem);
        if (listItem != null)
        {
            // Add the total value onto the stack
            listItem.UpdateStack(_value);
        }
        else
        {
            // Create new item and ui container
            InventoryItem createdItem = new InventoryItem(_newItem, _value, UIManager.instance.CreateInventoryContainer());
            createdItem.UpdateContainer();
            inventoryItems.Add(createdItem);
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
                listItem.UpdateStack(-1);
            }
            else
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
}
