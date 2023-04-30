using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private int health = 10;

    // Getter
    public int GetHealth() { return health; }
    public void IncreaseHealth() { health++; }
    public void DecreaseHealth() { health--; }
    public void SavePlayerHealth() { SaveSystem.SavePlayer(this); }
    
    public void LoadPlayerHealth()
    {
        // Find save data file
        PlayerData data = SaveSystem.LoadPlayer();
        // Assign old data
        health = data.health;
        transform.position = new Vector3(data.position[0], data.position[1], data.position[2]);
    }
}
