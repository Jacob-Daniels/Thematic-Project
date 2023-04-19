using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEditor;
using UnityEngine;

public class ToolManager : MonoBehaviour
{
    public static ToolManager instance;

    private Dictionary<Recipe, GameObject> tools = new Dictionary<Recipe, GameObject>();
    [SerializeField] private Recipe current;
    private int toolIndex = 0;
    
    // Getter
    public Dictionary<Recipe, GameObject> GetTools() { return tools; }

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
        tools.Add(current, GameObject.Find("Player/Main Camera/Hand/DestructibleGun"));
        Hotbar.instance.UpdateHotbar(toolIndex);
    }

    void Update()
    {
        // Get scroll input
        if (Input.GetAxisRaw("Mouse ScrollWheel") > 0)
        {
            if (toolIndex > 0)
            {
                toolIndex--;
            }
            else
            {
                toolIndex = tools.Count - 1;
            }
        } else if (Input.GetAxisRaw("Mouse ScrollWheel") < 0)
        {
            if (toolIndex < tools.Count - 1)
            {
                toolIndex++;
            }
            else
            {
                toolIndex = 0;
            }
        }
        // Update selected tool by index value
        selectTool(tools.ElementAt(toolIndex).Key, toolIndex);
    }

    public void AddTool(Recipe _recipe, GameObject toolObject)
    {
        // Add tool to dictionary if it is a new tool and not an upgrade
        if (_recipe.recipeType != "Upgradable Tool")
        {
            tools.Add(_recipe, toolObject);
            // Disable all tools
            foreach (GameObject unlockedTool in tools.Values) { unlockedTool.SetActive(false); }
            // Set tool index to latest tool in dictionary
            toolIndex = tools.Count - 1;
        }
        else
        {
            // Upgrade - Keep current tool active
            toolObject.SetActive(true);
            // Disable all tools
            foreach (GameObject unlockedTool in tools.Values) { unlockedTool.SetActive(false); }
            
            tools[current].SetActive(true);
        }
        // Update hotbar
        Hotbar.instance.UpdateHotbar(toolIndex);
    }

    void selectTool(Recipe _recipe, int _index)
    {
        // Change selected tool
        if (_recipe.name != current.name)
        {
            // Disable old tool and enable new one
            tools[current].SetActive(false);
            tools[_recipe].SetActive(true);
            current = tools.ElementAt(_index).Key;
            // Update hotbar
            Hotbar.instance.UpdateHotbar(toolIndex);
        }
    }
}
