using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    void Start()
    {

    }

    void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.tag != "Ground")
        {
            col.gameObject.GetComponent<BoxCollider>().enabled = false;
            col.gameObject.transform.SetParent(GameObject.Find("Player").GetComponent<Transform>());
        }
    }
}
