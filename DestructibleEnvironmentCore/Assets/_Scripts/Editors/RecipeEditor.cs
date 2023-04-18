using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

[CustomEditor(typeof(Recipe))]
public class RecipeEditor : Editor
{
    private SerializedProperty recipeName;
    private SerializedProperty icon;
    private SerializedProperty summary;
    private SerializedProperty itemsRequired;
    private SerializedProperty recipeItem;

    // Drop down properties
    private bool isItemDropdown = false;
    
    private void OnEnable()
    {
        recipeName = serializedObject.FindProperty("recipeName");
        icon = serializedObject.FindProperty("icon");
        summary = serializedObject.FindProperty("summary");
        itemsRequired = serializedObject.FindProperty("itemsRequired");
        recipeItem = serializedObject.FindProperty("recipeItem");
    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();
        
        // Get a pointer to the recipe script
        Recipe recipeScript = (Recipe)target;
        
        // Display properties in order
        EditorGUILayout.PropertyField(recipeName);
        EditorGUILayout.PropertyField(icon);
        EditorGUILayout.PropertyField(summary);

        // Create the drop down menu for the recipe type array
        GUIContent recipeTypeTitle = new GUIContent("Recipe type: ");
        recipeScript.recipeTypeIndex = EditorGUILayout.Popup(recipeTypeTitle, recipeScript.recipeTypeIndex, recipeScript.recipeTypes);
        // Assign recipe type when selected
        recipeScript.recipeType = recipeScript.recipeTypes[recipeScript.recipeTypeIndex];

        // Display box to assign item if recipe can craft one
        if (recipeScript.recipeType == "Item")
        {
            // Item is selected
            EditorGUILayout.PropertyField(recipeItem, new GUIContent("Item to craft:"));
        }
        
        // Display items required for recipe
        EditorGUILayout.PropertyField(itemsRequired);

        serializedObject.ApplyModifiedProperties();
    }
}
