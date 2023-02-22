using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    long sprint;
    float tempspeed, shiftspeed;
    public int sprintmax;
    public float speed, RotateValue, jumpValue;
    public Transform forward, strafe;
    bool cameraState, grounded;
    Rigidbody rb;

    private void Awake()
    {
        // Lock/hide the cursor for playermovement
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Start is called before the first frame update
    void Start()
    {
        grounded = true;
        cameraState = false;
        rb = GetComponent<Rigidbody>();
        sprint = 0;
        shiftspeed = 2 * speed;
        tempspeed = speed;
    }

    // Update is called once per frame
    void Update()
    {
        if(sprint < sprintmax && !Input.GetKey(KeyCode.LeftShift))
        {
            sprint++;
        }

        if (Input.GetKey(KeyCode.LeftShift) && sprint > 0)
        {
            speed = shiftspeed;
            sprint--;
        }
        else
        {
            speed = tempspeed;
        }

        if (Input.GetKey("w"))
        {
            transform.position = Vector3.MoveTowards(transform.position, forward.position, speed * Time.deltaTime);
        }
        else if (Input.GetKey("s"))
        {
            transform.position = Vector3.MoveTowards(transform.position, forward.position, -speed * Time.deltaTime);
        }

        if (Input.GetKey("a"))
        {
            transform.position = Vector3.MoveTowards(transform.position, strafe.position, speed * Time.deltaTime);
        }
        else if (Input.GetKey("d"))
        {
            transform.position = Vector3.MoveTowards(transform.position, strafe.position, -speed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.Space) && grounded)
        {
            grounded = !grounded;
            rb.AddForce(new Vector3(0, jumpValue, 0));
        }

        if (Input.GetKeyDown("t"))//this code is used to switch between 1st and 3rd person, currently buggy
        {
            cameraState = !cameraState;
        }

        transform.Rotate(new Vector3(0, Input.GetAxis("Mouse X") * RotateValue * Time.deltaTime, 0), Space.World);
    }

    void FixedUpdate() 
    {

        if (cameraState)
        {
            transform.GetChild(0).GetComponent<Transform>().localPosition = new Vector3(0, 1.5f, -2.75f);
        }
        else
        {
            transform.GetChild(0).GetComponent<Transform>().localPosition = new Vector3(0, 0, 0);
        }
    }

    void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.tag == "Ground")
        {
            grounded = true;
        }
    }
}
