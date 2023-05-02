using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

[CreateAssetMenu(fileName = "New Recipe", menuName = "Inventory/Recipe")]
public class Recipe : ScriptableObject
{
    // Scriptable object to create a recipe for an object
    public string recipeName;
    public Sprite icon;
    public string summary;
    public ItemProperties[] itemsRequired;

    // Recipe type properties
    [HideInInspector] public string[] recipeTypes = { "Tool", "Upgradable Tool", "Item" };
    [HideInInspector] public int recipeTypeIndex;
    [HideInInspector] public string recipeType;
    
    // Variables that appear depending on recipe type
    public ItemProperties recipeItem;
    public Recipe recipeToUpgrade;
}
