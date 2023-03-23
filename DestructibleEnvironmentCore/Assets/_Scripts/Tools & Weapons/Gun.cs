using System;
using System.Diagnostics;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public float damage = 10f, firerate = 15f, range = 10;
    public Camera fpsCam;
    bool holding = false;
    private Transform p;
    private int l;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire1"))//hold left click
        {
            Break();
        }
        if (Input.GetButtonDown("Fire2"))//hold right click to add to inventory
        {
            if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out RaycastHit hit, range)) //generate ray
            {
                if (hit.transform.gameObject.tag == "Movable") //only picks up objects that are movable
                {
                    holding = true;
                    p = hit.transform.parent.transform;
                    l = hit.transform.gameObject.layer;
                    hit.transform.gameObject.layer = 8; //ignore player collision layer
                    hit.transform.SetParent(transform.parent);
                    hit.transform.GetComponent<Rigidbody>().isKinematic = true;
                }
            }
        }
        else if (Input.GetButtonUp("Fire2") && holding)//release right click
        {
            holding = false;
            for(int i = 1; i < transform.parent.childCount; i++)
            {
                transform.parent.GetChild(i).gameObject.layer = l;
                transform.parent.GetChild(i).GetComponent<Rigidbody>().isKinematic = false;
                transform.parent.GetChild(i).GetComponent<Transform>().SetParent(p);
            }
        }
    }

    void addtoInventory()
    {
        //add to inventory
    }

    void Break()
    {
        //destructible objects on layer 9, inverse layer mask to ignore all layers except 9
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out RaycastHit hit, range, ~9)) //generate ray
        {
            hit.collider.GetComponent<Break>().BreakObject();
            addtoInventory();
        }
    }
}
