using System;
using UnityEngine;

public class DestructibleGun : MonoBehaviour
{
    [Header("Destructible Properties:")]
    [SerializeField] private Camera playerCamera;
    [SerializeField] private float aimDistance = 20f;
    [SerializeField] private LayerMask destructibleLayerMask;
    private RaycastHit hit;

    [Header("Vacuum Properties:")]
    [SerializeField] private GameObject vacuumGun;
    [SerializeField] private MeshCollider vacuumMesh;

    void Update()
    {
        // Return if UI is open
        if (UIManager.instance.displayInventory.activeSelf) { return; }

        // Destructible Gun
        if (Input.GetMouseButtonDown(0))
        {
            CheckToDestroy();
        }

        // Vacuum gun
        if (!vacuumGun.activeSelf) { return; }
        if (Input.GetMouseButtonDown(1))
        {
            vacuumMesh.enabled = true;
        }
        if (Input.GetMouseButtonUp(1))
        {
            vacuumMesh.enabled = false;
        }
    }
    private void CheckToDestroy()
    {
        // Check the object hit can be destroyed
        if (Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward, out hit, aimDistance, destructibleLayerMask))
        {
            hit.collider.GetComponent<Break>().BreakObject();
        }
    }
}
