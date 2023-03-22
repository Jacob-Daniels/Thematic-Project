using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    [SerializeField] private GameObject displayInventory;
    [SerializeField] private GameObject crosshairObj;

    [Header("Inventory Properties:")]
    [SerializeField] private GameObject inventoryContainerPrefab;
    [SerializeField] private Transform inventoryContainerParent;
    private Camera cam;

    private void Awake()
    {
        cam = GameObject.Find("Main Camera").GetComponent<Camera>();
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

    public void PlaceItem(GameObject Object)
    {
        Debug.Log("Placing");
        if(Physics.Raycast(cam.transform.position,cam.transform.forward, out RaycastHit hit, 9f)){
            GameObject g = Instantiate(Object);
            g.GetComponent<Transform>().position = hit.point + new Vector3(0, g.GetComponent<Transform>().localScale.y/2f,0);//instantiate object and set position to hit.point
            g.GetComponent<Transform>().localScale = new Vector3(1, 1, 1);
            MonoBehaviour[] mono = g.GetComponents<MonoBehaviour>();
            foreach(MonoBehaviour Mono in mono)// get all scripts and enable them
            {
                Mono.enabled = true;
            }
            Collider[] col = g.GetComponents<Collider>();
            foreach(Collider Col in col)//get all colliders and enable them
            {
                Col.enabled = true;
            }

            g.GetComponent<Transform>().SetParent(null);

        }
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
