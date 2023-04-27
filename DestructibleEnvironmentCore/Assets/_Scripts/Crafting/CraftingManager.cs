using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;
using UnityEngine.UI;

public class CraftingManager : MonoBehaviour
{
    public static CraftingManager instance;

    [Header("Crafing Properties:")]
    [SerializeField] private List<Recipe> craftedRecipes = new List<Recipe>();
    [SerializeField] private Recipe currentRecipe;
    [SerializeField] private GameObject toolObject;

    [Header("UI Container Properties:")]
    public TextMeshProUGUI nameText;
    public Image iconImage;
    public TextMeshProUGUI summaryText;
    public TextMeshProUGUI materialsText;

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

    #region UI Properties
    public void AssignRecipeData(Recipe _recipe)
    {
        // Assign recipe details (to display them in the ui)
        nameText.text = _recipe.recipeName;
        iconImage.sprite = _recipe.icon;
        iconImage.color = Color.white;
        summaryText.text = _recipe.summary;
        // Get item details
        string itemDetails = "";
        foreach (ItemProperties _item in _recipe.itemsRequired)
        {
            if (itemDetails == "")
            {
                itemDetails += _item.stack + " " + _item.item.name;
            } else
            {
                itemDetails += " and " + _item.stack + " " + _item.item.name;
            }
        }
        materialsText.text = itemDetails;
        currentRecipe = _recipe;
    }
    public void AssignToolObject(GameObject _tool)
    {
        // Assign object to enable when tool is crafted
        toolObject = _tool;
    }
    #endregion

    public void CraftRecipe()
    {
        // Return if recipe is null or already crafted
        if (toolObject == null || currentRecipe == null || craftedRecipes.Contains(currentRecipe)) { return; }

        // Check tool can be crafted
        if (CanToolBeCrafted())
        {
            // Remove each item from the inventory items to craft item
            foreach (ItemProperties _item in currentRecipe.itemsRequired)
            {
                Inventory.instance.RemoveItem(_item.item, _item.stack);
            }

            // Check type of recipe
            if (currentRecipe.recipeType == "Tool") {
                ToolManager.instance.AddTool(currentRecipe, toolObject);
                craftedRecipes.Add(currentRecipe);
            } else if (currentRecipe.recipeType == "Upgradable Tool")
            {
                // Enable new tool & add recipe to crafted list
                ToolManager.instance.AddTool(currentRecipe, toolObject);
                craftedRecipes.Add(currentRecipe);
            } else if (currentRecipe.recipeType == "Item")
            {
                // Add item to inventory
                Inventory.instance.AddItem(currentRecipe.recipeItem.item, currentRecipe.recipeItem.stack);
            }
            // Deselect recipe
            currentRecipe = null;
        }
        else
        {
            Debug.Log("COULDN'T CRAFT RECIPE");
            // Can't craft recipe (not enough materials)
            return;
        }
    }
    
    private bool CanToolBeCrafted()
    {
        // Check each item can be removed from the items list
        foreach (ItemProperties _item in currentRecipe.itemsRequired)
        {
            if (!Inventory.instance.CanRemoveItem(_item.item, _item.stack)) { return false; }
        }
        // All items exist in inventory items list (Result = can craft)
        return true;
    }
}
