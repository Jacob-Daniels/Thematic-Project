using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolManager : MonoBehaviour
{
    public static ToolManager instance;

    private Dictionary<string, GameObject> tools = new Dictionary<string, GameObject>();
    private List<string> toolNames = new List<string>();
    private string current = "Destructible Gun";

    // Getter
    public Dictionary<string, GameObject> GetTools() { return tools; }

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


    private void Start()
    {
        // Set starting tool / weapon
        tools.Add("Destructible Gun", GameObject.Find("Player/Main Camera/Hand/DestructibleGun"));
        toolNames.Add("Destructible Gun");
    }

    void Update()
    {
        // TEMPORARY CODE TO SELECT TOOLS (LOOK AT SCROLL WHEEL WITH A VARIABLE FOR THE CURRENT INDEX)
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            setActive(toolNames[0]);
            current = toolNames[0];
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            if (1 >= toolNames.Count) { return; }
            setActive(toolNames[1]);
            current = toolNames[1];
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            if (2 >= toolNames.Count) { return; }
            setActive(toolNames[2]);
            current = toolNames[2];
        }
    }

    public void AddTool(string name, GameObject toolObject)
    {
        // Add tool to dictionary
        tools.Add(name, toolObject);
        toolNames.Add(name);
    }

    void setActive(string s)
    {
        // Change selected tool
        if (s != current)
        {
            tools[current].SetActive(false);
            tools[s].SetActive(true);
        }
    }

    public void SetCurrent()
    {
        // Enable current tool (called when an item is crafted)
        tools[current].SetActive(true);
    }
}
