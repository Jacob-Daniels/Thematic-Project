using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
    public int health;
    // float array used instead of vector3 (cannot serialize a vector)
    public float[] position;

    // Constructor
    public PlayerData(PlayerHealth playerHealth)
    {
        health = playerHealth.GetHealth();
        // Set the position
        position = new float[3];
        position[0] = playerHealth.transform.position.x;
        position[1] = playerHealth.transform.position.y;
        position[2] = playerHealth.transform.position.z;
    }
}
