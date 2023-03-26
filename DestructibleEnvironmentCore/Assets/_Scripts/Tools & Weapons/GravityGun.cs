using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityGun : MonoBehaviour
{
    [Header("Raycast/Pickup Properties:")]
    [SerializeField] private Camera playerCamera;
    [SerializeField] private Transform playerHand;
    [SerializeField] private Transform pickupParent;
    [SerializeField] private float aimDistance = 20f;
    private RaycastHit hit;
    private Transform heldObject;
    bool holding = false;

    void Update()
    {
        // Return if UI is open
        if (UIManager.instance.displayInventory.activeSelf) { return; }

        // Right mouse click
        if (Input.GetMouseButtonDown(0))
        {
            PickUpObject();
        }
        if (Input.GetMouseButtonUp(0) && holding)
        {
            DropObject();
        }
    }

    private void PickUpObject()
    {
        // Grab object to move around
        if (Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward, out hit, aimDistance) && hit.transform.CompareTag("Movable"))
        {
            holding = true;
            heldObject = hit.transform;
            pickupParent = heldObject.parent.transform;
            heldObject.SetParent(playerHand.parent);
            heldObject.GetComponent<Rigidbody>().isKinematic = true;
        }
    }

    private void DropObject()
    {
        // Release object being held
        holding = false;
        heldObject.SetParent(pickupParent);
        heldObject.GetComponent<Rigidbody>().isKinematic = false;
    }
}