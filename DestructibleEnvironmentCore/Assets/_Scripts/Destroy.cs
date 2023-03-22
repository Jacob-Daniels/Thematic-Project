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
            Destroy(transform.gameObject);
        }
    }

    private void OnDestroy()
    {
        Destroy(transform.parent.gameObject);
    }
}
