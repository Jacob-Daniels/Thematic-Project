using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Recipe", menuName = "Inventory/Recipe")]
public class Recipe : ScriptableObject
{
    // Scriptable object to create a recipe for an object
    public string recipeName;
    public Sprite icon;
    public string summary;
    public bool isUpgradable;
    public ItemProperties[] itemsRequired;
}
