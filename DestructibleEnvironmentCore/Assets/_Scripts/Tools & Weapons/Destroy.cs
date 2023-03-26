using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour
{
    private float dist;
    [SerializeField] GameObject player;

    void Start()
    {
        player = GameObject.Find("Player");
    }
    private void Update()
    {
        dist = Mathf.Clamp(Vector3.Distance(transform.position, player.transform.position)-2f,0,1);
        Debug.Log(dist);
        transform.localScale = new Vector3(dist,dist,dist);
        if (dist <= 0.1)
        {
            // Destroy parent if object is its last child
            if (transform.parent.childCount <= 1)
            {
                Destroy(transform.parent.gameObject);
            }
            // Destroy object
            Destroy(transform.gameObject);
        }
    }
}
