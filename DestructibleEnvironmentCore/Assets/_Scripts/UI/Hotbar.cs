using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class Hotbar : MonoBehaviour
{
    public static Hotbar instance;
    [SerializeField] private GameObject[] hotbarSlots;

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

    public void UpdateHotbar(int _toolIndex)
    {
        // Disable all hotbar slots
        foreach (GameObject slot in hotbarSlots) { slot.SetActive(false); }

        // Set selected tool
        hotbarSlots[0].SetActive(true);
        hotbarSlots[0].transform.GetChild(0).GetComponent<Image>().sprite =
            ToolManager.instance.GetTools().ElementAt(_toolIndex).Key.icon;
        
        // Loop the rest of the tools
        int i = 1, j = _toolIndex + 1;
        while (i < hotbarSlots.Length)
        {
            if (j >= ToolManager.instance.GetTools().Count)
            {
                j = 0;
            }
            if (j == _toolIndex) { break; }

            // Set hotbar properties
            hotbarSlots[i].SetActive(true);
            hotbarSlots[i].transform.GetChild(0).GetComponent<Image>().sprite =
                ToolManager.instance.GetTools().ElementAt(j).Key.icon;
            i++;
            j++;
        }
    }
}
