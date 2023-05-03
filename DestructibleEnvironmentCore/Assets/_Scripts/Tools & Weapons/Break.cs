using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Break : MonoBehaviour
{
    public GameObject fractured;
    
    // Create delegate to call when spawning objects
    public static Action<Transform> OnBroken = delegate {};

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

    private void FixedUpdate()
    {
        if (transform.position.y < -1) // destroys objects that fall from the world
        {
            OnBroken?.Invoke(this.transform.parent.transform.parent);
            Destroy(gameObject);
        }
    }
}
