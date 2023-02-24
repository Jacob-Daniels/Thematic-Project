using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Recipe", menuName = "Inventory/Recipe")]
public class Recipe : ScriptableObject
{
    public string name;
    public string description;
    public int id;
    public RecipeRequirements[] itemsRequired;
}
