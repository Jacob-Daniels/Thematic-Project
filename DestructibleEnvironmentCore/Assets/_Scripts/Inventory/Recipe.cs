using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Recipe", menuName = "Inventory/Recipe")]
public class Recipe : ScriptableObject
{
    public string recipeName;
    public Sprite icon;
    public string summary;
    public string materialsSummary;
    public int id;
    public RecipeRequirements[] itemsRequired;
}
