using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Break : MonoBehaviour
{
    public GameObject fractured;

    void Update()
    {
        if (Input.GetKeyDown("f"))
        {
            BreakObject();
        }
    }

    public void BreakObject()
    {
        GameObject obj = Instantiate(fractured, transform.position, transform.rotation);
        obj.transform.localScale = new Vector3(gameObject.transform.localScale.x, gameObject.transform.localScale.y, gameObject.transform.localScale.z);
        Destroy(gameObject);
    }
}
