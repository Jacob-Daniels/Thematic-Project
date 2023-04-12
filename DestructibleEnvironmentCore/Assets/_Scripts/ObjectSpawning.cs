using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawning : MonoBehaviour
{
    public GameObject[] Spawners;
    public GameObject[] Objects;
    public static int ObjectCount;
    private int rs, ro;
    void Start()
    {
        for (int count = 0; count <= 40; count++) {
            Spawn();
            ObjectCount++;
        }

        Break.onBroken += Broken;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (ObjectCount < 10)
        {
            for (int count = 0; count <= 40; count++) {
                Spawn();
                ObjectCount++;
            }
        }
    }

    void Spawn()
    {
        rs = Random.Range(0, Spawners.Length - 1);
        ro = Random.Range(0, Objects.Length - 1);
        Instantiate(Objects[ro], Spawners[rs].transform);
    }

    void Broken()
    {
        ObjectCount--;
    }

}
