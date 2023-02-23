using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private int health = 10;
    [SerializeField] private TextMeshProUGUI healthText;

    // Getter
    public int GetHealth() { return health; }

    private void Update()
    {
        // Increase/decrease health
        if (Input.GetKeyDown(KeyCode.I))
        {
            IncreaseHealth();
        } else if (Input.GetKeyDown(KeyCode.O))
        {
            DecreaseHealth();
        }
        // Update health text
        healthText.text = "Health: " + health.ToString();

        // Save and load data
        if (Input.GetKeyDown(KeyCode.M))
        {
            SavePlayerHealth();
        } else if (Input.GetKeyDown(KeyCode.N))
        {
            LoadPlayerHealth();
        }
    }

    private void IncreaseHealth()
    {
        health++;
    }

    private void DecreaseHealth()
    {
        health--;
    }

    private void SavePlayerHealth()
    {
        SaveSystem.SavePlayer(this);
    }

    private void LoadPlayerHealth()
    {
        // Find save data file
        PlayerData data = SaveSystem.LoadPlayer();
        // Assign old data
        health = data.health;
        transform.position = new Vector3(data.position[0], data.position[1], data.position[2]);
    }
}
