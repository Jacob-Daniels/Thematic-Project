using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementv2 : MonoBehaviour
{
    [Header("Movement Properties:")]
    [SerializeField] public Rigidbody rigidbody;
    [SerializeField] public float movementSpeed = 3;
    [SerializeField] private float gravity = -9.81f;

    [Header("Jump/Grounded Properties:")]
    [SerializeField] private Transform groundTransform;
    [SerializeField] private LayerMask groundMask;
    [SerializeField] private float groundDistance = 0.5f;
    [SerializeField] private float jumpDistance = 10f;
    private bool isGrounded;

    void Update()
    {
        isGrounded = Physics.CheckSphere(groundTransform.position, groundDistance, groundMask);
        if (Input.GetButtonDown("Jump")&&isGrounded)
        {
            rigidbody.AddForce(transform.up * jumpDistance, ForceMode.Impulse);
        }
    }

    void FixedUpdate()
    {
        Vector3 movement = new Vector3();

        movement.x = Input.GetAxis("Horizontal");
        movement.z = Input.GetAxis("Vertical");
        movement *= Time.deltaTime;
        movement *= movementSpeed;

        Vector3 actualMovement = new Vector3();

        actualMovement += (transform.forward * movement.z);
        actualMovement += (transform.right * movement.x);


        rigidbody.velocity = rigidbody.velocity + actualMovement;
    }
}
