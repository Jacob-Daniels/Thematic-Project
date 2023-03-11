using UnityEngine;

public class Gun : MonoBehaviour
{
    public float damage = 10f, range = 100f, firerate = 15f;
    public Camera fpsCam;
    //public GameObject bullet;

    private float reload = 0f;
    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire1"))//hold left click
        {
            Shoot();
        }
        else if (Input.GetButtonUp("Fire1"))//release left click
        {
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
        else if(Input.GetButtonUp("Fire2"))//release right click
        {
            removefromInventory();
        }
    }

    void Shoot()
    {
        RaycastHit hit;
        if(Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))//generate ray
        {
            Debug.Log(hit.transform.name);

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

    void removefromInventory()
    {
        //remove code goes here
    }
}
