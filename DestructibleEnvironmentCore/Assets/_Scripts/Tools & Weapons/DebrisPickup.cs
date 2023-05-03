using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebrisPickup : MonoBehaviour
{
    [SerializeField] private GameObject player;
    private float dist;

    private float vacuumSpeed;
    private bool isVacuum;
    
    // Create delegate to call when spawning objects
    public static Action<Transform> OnBroken = delegate {};
    void Start()
    {
        player = GameObject.Find("Player");
    }

    private void FixedUpdate()
    {
        // Is being vacuumed
        if (isVacuum)
        {
            transform.position = Vector3.MoveTowards(transform.position, player.transform.position, vacuumSpeed * Time.deltaTime);
        }

        // Check to destroy the object (if player collides with it)
        dist = Mathf.Clamp(Vector3.Distance(transform.position, player.transform.position) - 2f, 0, 1);
        transform.localScale = new Vector3(dist, dist, dist);
        if (dist <= 0.1)
        {
            PickupObject();
        }
        
        if (transform.position.y < -1) // destroys objects that fall from the world
        {
            if (transform.parent.childCount <= 1)
            {
                OnBroken?.Invoke(this.transform.parent.transform.parent.transform.parent);
                Destroy(transform.parent.gameObject);
            }
            Destroy(gameObject);
        }
    }
    
    private void PickupObject()
    {
        // Add items to inventory
        gameObject.GetComponent<PickupItems>().CalculateItemsDropped();
        // Destroy object
        Destroy(transform.gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Vacuum"))
        {
            // Set speed
            isVacuum = true;
            vacuumSpeed = other.GetComponent<VacuumGun>().GetVacuumSpeed();
        }
    }
}
