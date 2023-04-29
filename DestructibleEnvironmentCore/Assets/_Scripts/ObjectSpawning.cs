using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class ObjectSpawning : MonoBehaviour
{
    public GameObject[] Spawners;
    public GameObject[] Objects;
    public static int ObjectCount;
    private int rs, ro;
    private const int maxObjects = 15;
    
    void Start()
    {
        // Spawn all objects
        for (int count = 0; count <= maxObjects; count++)
        {
            Spawn();
            ObjectCount++;
        }
        // Add method to delegate from Break script 
        Break.onBroken += Broken;
        //Break.onBroken += Spawn;
    }
    
    void FixedUpdate()
    {
         //Commented out as objects now spawn when broken (instead of when the count is below 10)
        // Spawn objects when total is less than 10
        if (ObjectCount < 10)
        {
            for (int count = 0; count <= maxObjects; count++) {
                Spawn();
                ObjectCount++;
            }
        }
    }

    void Spawn()
    {
        // Generate random asset and spawn platform
        rs = Random.Range(0, Spawners.Length);
        ro = Random.Range(0, Objects.Length);
        // Spawn object
        //Instantiate(Objects[ro], Spawners[rs].transform);
        Instantiate(Objects[ro], Spawners[rs].transform).transform.rotation = Random.rotation;
    }

    void Broken()
    {
        Debug.Log(ObjectCount);
        ObjectCount--;
    }
}
