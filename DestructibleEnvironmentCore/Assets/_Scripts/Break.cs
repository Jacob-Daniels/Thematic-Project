using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Break : MonoBehaviour
{
    public GameObject fractured;

    public void BreakObject()
    {
        // Instantiate shattered object & delete old object
        GameObject obj = Instantiate(fractured, transform.position, transform.rotation);
        obj.transform.localScale = new Vector3(gameObject.transform.localScale.x, gameObject.transform.localScale.y, gameObject.transform.localScale.z);
        StartCoroutine(DestroyObject());
    }

    IEnumerator DestroyObject()
    {
        yield return new WaitForSeconds(0.05f);
        Destroy(gameObject);
    }
}
