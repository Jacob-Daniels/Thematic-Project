using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GrapplingHook : MonoBehaviour
{
    [SerializeField] private PlayerMovement playerMovement;
    [SerializeField] private Transform handParent;
    [SerializeField] private Transform playerBody;
    [SerializeField] private LayerMask grappleLayer;
    [SerializeField] private LineRenderer lineRenderer;
    [SerializeField] private Transform lrStart;

    [Header("Hook Properties:")]
    [SerializeField] private float maxGrappleDistance;
    [SerializeField] private float hookSpeed;
    [SerializeField] private float moveSpeed;
    [SerializeField] private Vector3 offset;
    [SerializeField] private float breakDistance;
    [SerializeField] private bool isShooting, isGrappling;
    private Vector3 hookPoint;


    void Start()
    {
        // Initialise variables upon start up
        isShooting = false;
        isGrappling = false;
    }

    void Update()
    {
        // Input to shoot grapple gun
        if (Input.GetMouseButtonDown(1))
        {
            ShootHook();
        }
        // Release grapple on mouse release
        if (Input.GetMouseButtonUp(1))
        {
            StopGrapple();
        }

        // Check if user is grappling
        if (isGrappling)
        {
            // Update lr position
            lineRenderer.SetPosition(0, lrStart.position);

            // Move position of hook towards the raycast point (If within distance)
            if (Vector3.Distance(transform.position, hookPoint) < breakDistance)
            {
                transform.position = Vector3.Lerp(transform.position, hookPoint, hookSpeed * Time.deltaTime);
            }
            // Move position of player towards hook (If within distance)
            if (Vector3.Distance(playerBody.position, hookPoint - offset) > breakDistance)
            {
                // Update player position
                playerMovement.enabled = false;
                playerBody.position = Vector3.Lerp(playerBody.position, hookPoint - offset, moveSpeed * Time.deltaTime);
            } else
            {
                // Player reached hook
                StopGrapple();
            }
        }
    }

    private void StopGrapple()
    {
        // Reset properties of hook
        lineRenderer.enabled = false;
        playerMovement.enabled = true;
        isGrappling = false;
        isShooting = false;
        // Set parent
        transform.SetParent(handParent);
        transform.localPosition = new Vector3(-0.85f, 0.9f, 0f);
        transform.localRotation = Quaternion.Euler(new Vector3(0, 0, 0));
        transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
    }

    private void ShootHook() 
    {
        // Shoot hook at object
        if (isShooting || isGrappling) return;

        isShooting = true;
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit, maxGrappleDistance, grappleLayer)) 
        {
            hookPoint = hit.point;
            isGrappling = true;
            transform.parent = null;
            transform.LookAt(hookPoint);
            // Line renderer
            lineRenderer.enabled = true;
            lineRenderer.SetPosition(1, hookPoint);
        }
        isShooting = false;
    }
}
