using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Break : MonoBehaviour
{
    public GameObject fractured;

    public void BreakObject()
    {
        // Instantiate shattered object & delete old object
        GameObject obj = Instantiate(fractured, transform.position, transform.rotation, transform.parent);
        obj.transform.localScale = new Vector3(gameObject.transform.localScale.x, gameObject.transform.localScale.y, gameObject.transform.localScale.z);
        StartCoroutine(DestroyObject());
    }

    IEnumerator DestroyObject()
    {
        // Destroy object after time to push out shattered objects
        yield return new WaitForSeconds(0.05f);
        Destroy(gameObject);
    }
}
