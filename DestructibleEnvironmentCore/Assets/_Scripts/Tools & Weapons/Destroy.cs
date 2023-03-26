using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour
{
    private void Update()
    {
        if (transform.localScale.x <= 0)
        {
            // Destroy parent if object is its last child
            if (transform.parent.childCount == 1)
            {
                Destroy(transform.parent.gameObject);
            }
            // Destroy object
            Destroy(transform.gameObject);
        }
    }
}
