using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class Despawner : MonoBehaviour
{
    public static Action<Transform> OnBroken = delegate {};
    private void FixedUpdate()
    {
        if (transform.childCount <= 0) // destroys objects that fall from the world
        {
            OnBroken?.Invoke(this.transform.parent.transform.parent);
            Destroy(gameObject);
        }
    }
}
