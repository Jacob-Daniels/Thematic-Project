using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void StartGame()
    {
        // Load the next scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void SettingsMenu()
    {
        // Display the settings menu
        Debug.Log("OPEN SETTINGS");
    }
    
    public void QuitGame()
    {
        // Close application
        Application.Quit();
    }

    public void ResartGame()
    {
        // Load first scene to restart game
        SceneManager.LoadScene(0);
    }
}
