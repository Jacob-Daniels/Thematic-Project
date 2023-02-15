using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{

    public float speed, RotateValue;
    public Transform forward, strafe;
    bool cameraState;
    // Start is called before the first frame update
    void Start()
    {
        cameraState = false;
    }

    // Update is called once per frame
    void Update()
    {
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

        transform.Rotate(new Vector3(0, Input.GetAxis("Mouse X") * RotateValue * Time.deltaTime, 0), Space.World);
    }

    /*void FixedUpdate() //this code is used to switch between 1st and 3rd person, currently buggy
    {
        if (Input.GetKey("t"))
        {
            cameraState = !cameraState;
        }

        if (cameraState)
        {
            transform.GetChild(0).GetComponent<Transform>().localPosition = new Vector3(0, 1.5f, -2.75f);
        }
        else
        {
            transform.GetChild(0).GetComponent<Transform>().localPosition = new Vector3(0, 0, 0);
        }
    }*/
}
