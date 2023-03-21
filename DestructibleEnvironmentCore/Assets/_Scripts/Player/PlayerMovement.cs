using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement Properties:")]
    [SerializeField] private Rigidbody rb;
    [SerializeField] private float speed = 30f;
    [SerializeField] private float gravity = -9.81f;

    [Header("Jump/Grounded Properties:")]
    [SerializeField] private Transform groundTransform;
    [SerializeField] private LayerMask groundMask;
    [SerializeField] private float groundDistance = 0.5f;
    [SerializeField] private float jumpDistance = 10f;
    private bool isGrounded;

    private void Update()
    {
        // Check for collision with the "ground" layer
        isGrounded = Physics.CheckSphere(groundTransform.position, groundDistance, groundMask);

        // Apply gravity
        if (rb.velocity.y < 0f && isGrounded)
        {
            rb.velocity = new Vector3(rb.velocity.x, -2f, rb.velocity.z);
        }
        else
        {
            rb.velocity += new Vector3(0f, rb.velocity.y + gravity, 0f) * Time.deltaTime * Time.deltaTime;
        }
        // Jump
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.AddForce(transform.up * jumpDistance, ForceMode.Impulse);
        }
    }

    private void FixedUpdate()
    {

        // Get local movement
        Vector3 localMove = transform.right * Input.GetAxis("Horizontal") + transform.forward * Input.GetAxis("Vertical");

        // Move player & reset angular velocity
        rb.angularVelocity = new Vector3(0, 0, 0);
        rb.MovePosition(transform.position + localMove * speed * Time.deltaTime);
    }
}
