using UnityEngine;

public class Gun : MonoBehaviour
{
    public float damage = 10f, firerate = 15f, range = 10;
    public Camera fpsCam;
    public GameObject inventoryManager, UIManager;
    bool holding = false;
    private Transform p;

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
                    hit.collider.enabled = false;
                    p = hit.transform.parent.transform;
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
                transform.parent.GetChild(i).GetComponent<Rigidbody>().isKinematic = false;
                transform.parent.GetChild(i).GetComponent<Collider>().enabled = true;
                transform.parent.GetChild(i).GetComponent<Transform>().SetParent(p);
            }
        }
        if (Input.GetKey("e"))
        {
            if(transform.childCount == 1)
            {
                UIManager.GetComponent<UIManager>().PlaceItem(transform.GetChild(0).gameObject);
                Destroy(transform.GetChild(0).gameObject);
            }
        }
    }

    void addtoInventory(GameObject hit)
    {
        //add to inventory
        //inventoryManager.GetComponent<Inventory>().AddItem(hit);
    }

    void Break()
    {
        //destructible objects on layer 9, inverse layer mask to ignore all layers except 9
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out RaycastHit hit, range, ~9)) //generate ray
        {
            hit.collider.GetComponent<Break>().BreakObject();
            addtoInventory(hit.collider.gameObject);
        }
    }
}
