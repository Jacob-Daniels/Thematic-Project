using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    private void Awake()
    {
        // Singleton
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    
    public void LevelComplete()
    {
        // Load the following scene (As current scene/level is complete)
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
