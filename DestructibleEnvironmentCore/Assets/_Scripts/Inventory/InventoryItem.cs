using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class InventoryItem
{
    public Item item;
    public int stack;
    public GameObject uiContainer;

    public InventoryItem(Item item, GameObject container)
    {
        this.item = item;
        this.stack = 1;
        this.uiContainer = container;
    }

    public void UpdateContainer()
    {
        // Update container ui elements
        uiContainer.transform.GetChild(0).GetComponent<Image>().sprite = item.sprite;   // Sprite
        uiContainer.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = item.name; // Name
        uiContainer.transform.GetChild(2).GetComponent<TextMeshProUGUI>().text = stack.ToString(); // Stack
    }

    public void UpdateStack(int _value)
    {
        stack += _value;
        UpdateContainer();
    }
}
