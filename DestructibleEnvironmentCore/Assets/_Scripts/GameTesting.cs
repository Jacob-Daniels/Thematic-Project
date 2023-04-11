using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

/*
 * This is a temporary script to test aspects of the game.
 * Keep it all contained in this class so we can easily remove it at the end of the project
 */

public class GameTesting : MonoBehaviour
{
    [SerializeField] private GameObject testUIObject;
    private bool isActive;
    
    [Header("Testing Properties:")]
    [SerializeField] private TextMeshProUGUI healthText;
    private PlayerHealth playerHealth;
    
    private void Awake()
    {
        // Grab components
        playerHealth = GameObject.Find("Player").GetComponent<PlayerHealth>();
        isActive = true;
    }

    void Update()
    {
        // Activate testing script
        if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            isActive = isActive ? false : true;
        }

        // Allow input for testing and set properties
        if (isActive)
        {
            testUIObject.SetActive(true);
            
            // Save System
            if (Input.GetKeyDown(KeyCode.M))
            {
                playerHealth.SavePlayerHealth();
            } else if (Input.GetKeyDown(KeyCode.N))
            {
                playerHealth.LoadPlayerHealth();
            }
            
            // Player health
            if (Input.GetKeyDown(KeyCode.I))
            {
                playerHealth.IncreaseHealth();
            } else if (Input.GetKeyDown(KeyCode.O))
            {
                playerHealth.DecreaseHealth();
            }
            healthText.text = "Health: " + playerHealth.GetHealth().ToString();
        }
        else
        {
            testUIObject.SetActive(false);
        }
    }
}
