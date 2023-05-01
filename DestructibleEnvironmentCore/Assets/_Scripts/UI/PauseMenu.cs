using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    [Header("Pause Menu:")]
    [SerializeField] private GameObject pausePanel;

    void Update()
    {
        // Input to pause game
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (pausePanel.activeSelf)
            {
                UnpauseGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    public void PauseGame()
    {
        pausePanel.SetActive(true);
        Time.timeScale = 0.0f;
        Cursor.lockState = CursorLockMode.None;
    }

    public void UnpauseGame()
    {
        pausePanel.SetActive(false);
        Time.timeScale = 1.0f;
        Cursor.lockState = CursorLockMode.Locked;
    }
}
