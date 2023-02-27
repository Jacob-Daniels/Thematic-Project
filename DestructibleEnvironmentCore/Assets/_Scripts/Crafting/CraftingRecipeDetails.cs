using OpenCover.Framework.Model;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CraftingRecipeDetails : MonoBehaviour
{
    [Header("Container Properties:")]
    public TextMeshProUGUI nameText;
    public Image iconImage;
    public TextMeshProUGUI summaryText;
    public TextMeshProUGUI materialsText;

    public void AssignRecipeData(Recipe recipe)
    {
        nameText.text = recipe.recipeName;
        iconImage.sprite = recipe.icon;
        summaryText.text = recipe.summary;
        materialsText.text = recipe.materialsSummary;
    }
}
