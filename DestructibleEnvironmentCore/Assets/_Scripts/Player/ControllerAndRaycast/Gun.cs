using UnityEngine;

public class Gun : MonoBehaviour
{
    public float damage = 10f, range = 100f, firerate = 15f;
    public Camera fpsCam;
    public GameObject bullet;

    private float reload = 0f;
    // Update is called once per frame
    void Update()
    {
        if(Input.GetButton("Fire1") && Time.time >= reload)
        {
            reload = Time.time + 1f / firerate;
            Shoot();
        }
    }

    void Shoot()
    {
        RaycastHit hit;
        if(Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.name);
            //Enemy enemy = hit.transform.GetComponent<Enemy>();
            //if(enemy != null)
            //{
            //    enemy.TakeDamage(damage);
            //}

            if(hit.transform.name == "Door")
            {
                hit.collider.gameObject.GetComponent<Rigidbody>().AddForce(Vector3.right * 2000);
            }

            GameObject Bullet = Instantiate(bullet, hit.point, Quaternion.LookRotation(hit.normal));
            Destroy(Bullet, 0.5f);
        }
    }
}
