using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName ="Inventory/Item")]
public class Item : ScriptableObject
{
    // Scriptable object to create items
    public string name;
    public int id;
    public Sprite sprite;
}
