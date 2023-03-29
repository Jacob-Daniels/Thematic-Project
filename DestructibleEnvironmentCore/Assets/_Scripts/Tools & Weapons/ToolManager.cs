using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolManager : MonoBehaviour
{
    private Dictionary<string, GameObject> tools = new Dictionary<string, GameObject>();
    private string current = "Destroy";
    // Update is called once per frame
    private void Start()
    {
        tools.Add("Destroy", GameObject.Find("Player/Main Camera/Hand/DestructibleGun"));
        tools.Add("Pickup", GameObject.Find("Player/Main Camera/Hand/GravityGun"));
        tools.Add("Grapple", GameObject.Find("Player/Main Camera/Hand/GrappleGun"));
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            setActive("Destroy");
            current = "Destroy";
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            setActive("Pickup");
            current = "Pickup";
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3) && tools["Grapple"].GetComponentInChildren<GrapplingHook>().isCrafted == true)
        {
            setActive("Grapple");
            current = "Grapple";
        }
    }

    void setActive(string s)
    {
        if (s != current)
        {
            tools[current].SetActive(false);
            tools[s].SetActive(true);
        }
    }
}
