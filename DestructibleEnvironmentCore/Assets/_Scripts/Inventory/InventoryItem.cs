using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

// Called to from the 'Inventory' class to store items with different properties
[System.Serializable]
public class InventoryItem : ItemProperties
{
    public GameObject uiContainer;

    public InventoryItem(Item item, int stack, GameObject container)
    {
        this.item = item;
        this.stack = stack;
        this.uiContainer = container;
    }

    public void UpdateContainer()
    {
        // Update container ui elements
        uiContainer.transform.GetChild(0).GetComponent<Image>().sprite = item.sprite;   // Sprite
        uiContainer.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = item.name; // Name
        uiContainer.transform.GetChild(2).GetComponent<TextMeshProUGUI>().text = stack.ToString(); // Stack
    }

    public void AddToStack(int _value)
    {
        stack += _value;
        UpdateContainer();
    }
    public void RemoveFromStack(int _value)
    {
        stack -= _value;
        UpdateContainer();
    }
}
