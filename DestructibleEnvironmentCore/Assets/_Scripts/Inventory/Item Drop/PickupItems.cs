using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Calculates the types of items being adding to the inventory when user destroys an object
public class PickupItems : MonoBehaviour
{
    [SerializeField] private ItemDrop[] itemDrops;

    public void CalculateItemsDropped()
    {
        // Calculate the types of items dropped when object is destroyed
        foreach (ItemDrop _item in itemDrops)
        {
            // Check item can be dropped (basic percentage calculation)
            int randomPercentage = (int)Random.Range(0, 100);
            if (randomPercentage < _item.dropChance)
            {
                // Get random drop amount
                int dropAmount = (int)Random.Range(_item.minDrop, _item.maxDrop);
                if (dropAmount > 0)
                {
                    // Add item to inventory
                    Inventory.instance.AddItem(_item.item, dropAmount);
                    UIManager.instance.CreatePickupContainer(_item.item, dropAmount);
                }
            }
        }
    }
}
