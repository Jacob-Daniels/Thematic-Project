using System.Diagnostics;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public float damage = 10f, range = 100f, firerate = 15f;
    public Camera fpsCam;
    bool holding = false;
    public GameObject barrel;

    private float reload = 0f;
    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire1"))//hold left click
        {
            Pickup();
        }
        else if (Input.GetButtonUp("Fire1") && holding)//release left click
        {
            holding = false;
            for(int i = 3; i < transform.parent.childCount; i++)
            {
                transform.parent.GetChild(i).GetComponent<Collider>().enabled = true;
                transform.parent.GetChild(i).GetComponent<Transform>().SetParent(null);
            }
        }
        if (Input.GetButtonDown("Fire2"))//hold right click to add to inventory
        {
            addtoInventory();
        }
    }

    void Shoot()
    {
        RaycastHit hit;
        if(Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))//generate ray
        {
            if(hit.transform.gameObject.layer != 3)//wont pickup anything on layer 3
            {
                hit.collider.enabled = false;
                hit.transform.SetParent(transform.parent);
            }
        }
    }

    void addtoInventory()
    {
        //add to inventory
    }

    void Pickup()
    {
        RaycastHit hit;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))//generate ray
        {
            if (hit.transform.gameObject.tag == "Movable")//only picks up objects that are movable
            {
                holding = true;
                hit.collider.enabled = false;
                hit.transform.SetParent(transform.parent);
            }
            else if (hit.transform.gameObject.tag == "Barrel")
            {
                hit.collider.GetComponent<Break>().BreakObject();
                //GameObject newObject = Instantiate(barrel, hit.transform.position, hit.transform.rotation, hit.transform.parent);
            }
        }
    }
}
