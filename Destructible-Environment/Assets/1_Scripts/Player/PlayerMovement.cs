using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;
    public float speed = 12f;

    [Header("Grounded Properties:")]
    public float jumpHeight = 3f;
    public Vector3 velocity;
    public float gravity = -9.81f;
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    private bool grounded;

    void Update()
    {
        // Create sphere around groundCheck to check if player is colliding with ground
        grounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        // Check if grounded to reset y velocity
        if (grounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        // Get movement input
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        // Get movement locally
        Vector3 move = transform.right * x + transform.forward * z;
        // Move player
        controller.Move(move * speed * Time.deltaTime);

        if (Input.GetButtonDown("Jump") && grounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2 * gravity);
        }

        // Apply gravity when player isn't grounded
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }
}
