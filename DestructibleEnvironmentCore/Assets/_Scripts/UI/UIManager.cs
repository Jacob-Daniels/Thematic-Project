using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    [SerializeField] public GameObject displayInventory;
    [SerializeField] private GameObject crosshairObj;

    [Header("Inventory Properties:")]
    [SerializeField] private GameObject inventoryContainerPrefab;
    [SerializeField] private Transform inventoryContainerParent;

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
                Time.timeScale = 1f;
            }
            else
            {
                // Enable UI tab
                displayInventory.SetActive(true);
                crosshairObj.SetActive(false);
                Cursor.lockState = CursorLockMode.None;
                Time.timeScale = 0f;
            }
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
}
