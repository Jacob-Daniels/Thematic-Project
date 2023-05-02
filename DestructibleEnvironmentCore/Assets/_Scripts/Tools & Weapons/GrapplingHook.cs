using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GrapplingHook : MonoBehaviour
{
    [SerializeField] private PlayerMovement playerMovement;
    [SerializeField] private Transform playerBody;
    [SerializeField] private LayerMask grappleLayer;
    [SerializeField] private LineRenderer lineRenderer;
    [SerializeField] private Transform lrStart;
    [SerializeField] private Rigidbody playerRB;
    
    [Header("Hook Properties:")]
    [SerializeField] private float maxGrappleDistance;
    [SerializeField] private float moveSpeed;
    [SerializeField] private Vector3 offset;
    [SerializeField] private float breakDistance;
    [SerializeField] private float bounceDistance;
    [SerializeField] private bool isShooting, isGrappling;
    private Vector3 hookPoint;
    private float gravity;
    [SerializeField] private bool canPull = true;
    
    void Start()
    {
        // Initialise variables upon start up
        isShooting = false;
        isGrappling = false;
    }

    void Update()
    {
        // Input to shoot grapple gun
        if (Input.GetMouseButtonDown(0))
        {
            ShootHook();
        }
        // Release grapple on mouse release
        if (Input.GetMouseButtonUp(0))
        {
            StopGrapple();
            canPull = true;
        }

        // Check if user is grappling
        if (isGrappling)
        {
            // Stop player gravity / y velocity
            //playerRB.velocity = new Vector3(playerRB.velocity.x, 0.0f, playerRB.velocity.z);
            
            // Update lr position
            lineRenderer.SetPosition(0, lrStart.position);

            // Move position of player towards hook (If within distance)
            if (Vector3.Distance(playerBody.position, hookPoint - offset) > breakDistance && canPull)
            {
                playerMovement.enabled = false;
                //playerBody.position = Vector3.Lerp(playerBody.position, hookPoint - offset, moveSpeed * Time.deltaTime);
                // Stop player gravity / y velocity
                playerRB.velocity = new Vector3(playerRB.velocity.x, 0.0f, playerRB.velocity.z);
                
                // Update player position
                playerRB.MovePosition(Vector3.MoveTowards(playerBody.position, hookPoint - offset, moveSpeed));
            } else if (Vector3.Distance(playerBody.position, hookPoint - offset) > bounceDistance && !canPull)
            {
                // Bounce player back up to target whilst grappling
                canPull = true;
            } 
            else
            {
                // Player reached hook
                playerMovement.enabled = true;
                canPull = false;
                //StopGrapple();
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
        // Set position of gun to players hand
        transform.localPosition = new Vector3(0.0f, 0.27f, 0.85f);
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
            transform.LookAt(hookPoint);
            // Line renderer
            lineRenderer.enabled = true;
            lineRenderer.SetPosition(1, hookPoint);
        }
        isShooting = false;
    }
}
