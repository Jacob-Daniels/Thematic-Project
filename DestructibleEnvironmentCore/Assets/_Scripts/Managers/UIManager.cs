using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject displayInventory;

    private void Update()
    {
        // Input to change inventory state
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            // Enable / Disable UI
            if (displayInventory.activeSelf)
            {
                displayInventory.SetActive(false);
                Cursor.lockState = CursorLockMode.Locked;
                Time.timeScale = 1f;
            }
            else
            {
                displayInventory.SetActive(true);
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
}
