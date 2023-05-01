using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{
    [SerializeField] private PlayerLook playerLookScript;
    [SerializeField] private Slider sensitivitySlider;
    
    private void Awake()
    {
        
    }

    private void Start()
    {
        // Grab script
        if (!playerLookScript) { playerLookScript = GameObject.Find("Player").transform.GetChild(0).GetComponent<PlayerLook>(); }
        // Set sensitivity
        sensitivitySlider.value = playerLookScript.GetSensitivity();
    }

    public void Sensitivity(float sliderValue)
    {
        playerLookScript.SetSensitivity(sliderValue);
    }
}
