using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickupDisplay : MonoBehaviour
{
    [SerializeField] private float timer;
    [SerializeField] private CanvasGroup objectFade;
    
    private void Update()
    {
        // Decrease timer, then destroy
        if (timer <= 0.0f) { Destroy(gameObject); }
        timer -= Time.deltaTime;
        objectFade.alpha = timer / 2;
    }
 
    public void Delete() { Destroy(gameObject); }
}
