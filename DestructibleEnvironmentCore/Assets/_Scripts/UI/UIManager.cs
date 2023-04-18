using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    [SerializeField] public GameObject displayInventory;
    [SerializeField] private GameObject crosshairObj;
    [SerializeField] private PlayerLook playerLookScript;
    [SerializeField] private PlayerMovement playerMovement;
    
    [Header("Inventory Properties:")]
    [SerializeField] private GameObject inventoryContainerPrefab;
    [SerializeField] private Transform inventoryContainerParent;

    [Header("Pickup Properties:")]
    [SerializeField] private int maxPopups = 5;
    [SerializeField] private GameObject pickupContainerPrefab;
    [SerializeField] private GameObject pickupContainerParent;

    private void Awake()
    {
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
        // Input to change inventory state
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (displayInventory.activeSelf)
            {
                // Disable UI tab
                displayInventory.SetActive(false);
                crosshairObj.SetActive(true);
                Cursor.lockState = CursorLockMode.Locked;
                // Enable player movement
                playerLookScript.enabled = true;
                playerMovement.enabled = true;
            }
            else
            {
                // Enable UI tab
                displayInventory.SetActive(true);
                crosshairObj.SetActive(false);
                Cursor.lockState = CursorLockMode.None;
                // Stop player movement
                playerLookScript.enabled = false;
                playerMovement.enabled = false;
            }
        }
        CheckPopupCount();
    }

    private void CheckPopupCount()
    {
        // Limit number of pickup popups on screen
        if (pickupContainerParent.transform.childCount > maxPopups)
        {
            // Delete oldest child
            pickupContainerParent.transform.GetChild(0).GetComponent<PickupDisplay>().Delete();
        }
    }
    
    public void PlaceItem()
    {
        displayInventory.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Time.timeScale = 1f;
    }

    public GameObject CreateInventoryContainer()
    {
        // Create container for inventory item
        return Instantiate(inventoryContainerPrefab, inventoryContainerParent.transform);
    }

    public void CreatePickupContainer(Item pickupItem, int pickupAmount)
    {
        CheckPopupCount();
        // Create a new pickup container (When item is picked up)
        GameObject newContainer = Instantiate(pickupContainerPrefab, pickupContainerParent.transform);
        newContainer.transform.GetChild(0).GetComponent<Image>().sprite = pickupItem.sprite;
        newContainer.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = pickupItem.name + " x" + pickupAmount.ToString();
    }
}
