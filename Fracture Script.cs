using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Break : MonoBehaviour
{
    public GameObject fractured;

    void Update()
    {
        if(Input.GetKeyDown("f"))
            BreakTheThing();
    }

    public void BreakTheThing()
    {
        Instantiate(fractured, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
