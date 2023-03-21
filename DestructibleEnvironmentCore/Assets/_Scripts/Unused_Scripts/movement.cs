using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public CharacterController controller;
    public Transform groundCheck;
    public float speed = 12f, gravity = -9.81f, groundDistance = 0.4f , jumpHeight = 3f;
    public LayerMask groundMask;
    float x, z;
    Vector3 move, velocity;
    bool grounded;

    // Update is called once per frame
    void Update()
    {
        grounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        if(grounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }
        x = Input.GetAxis("Horizontal");
        z = Input.GetAxis("Vertical");
        move = transform.right * x + transform.forward * z;
        controller.Move(move * speed * Time.deltaTime);

        if(Input.GetButtonDown("Jump") && grounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
            Debug.Log(velocity.y);
        }

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
    }
}
