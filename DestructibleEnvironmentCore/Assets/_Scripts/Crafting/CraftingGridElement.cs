using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CraftingGridElement : MonoBehaviour
{
    [SerializeField] private Recipe itemRecipe;
    [SerializeField] private GameObject toolObject;
    [SerializeField] private Image itemIcon;
    [SerializeField] private TextMeshProUGUI itemName;

    private void Start()
    {
        // Assign data
        itemIcon.sprite = itemRecipe.icon;
        itemName.text = itemRecipe.recipeName;
    }

    public void CraftRecipe()
    {
        CraftingManager.instance.AssignRecipeData(itemRecipe);
        // Enable tool if it exists
        if (toolObject)
        {
            CraftingManager.instance.AssignToolObject(toolObject);
        }
    }
}
