using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OldGrapplingGun : MonoBehaviour
{
    private LineRenderer lr;
    private Vector3 grapplePoint;
    public LayerMask whatIsGrappleable;
    public Transform gunTip, camera,player;
    private float maxDistance = 100f;
    private SpringJoint joint;
    void Awake()
    {
        lr = GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
       
        if (Input.GetMouseButtonDown(0))
        {
            StartGrapple();
        }
        else if (Input.GetMouseButtonDown(0)) 
        {
            StopGrapple();
        }
    }
    private void LateUpdate()
    {
        DrawRope();
    }

    void StartGrapple() 
    {
        RaycastHit hit;
        if (Physics.Raycast(camera.position, camera.forward, out hit, maxDistance)) 
        {
            grapplePoint= hit.point;
            joint = player.gameObject.AddComponent<SpringJoint>();
            joint.autoConfigureConnectedAnchor= false;
            joint.connectedAnchor= grapplePoint;

            float distanceFromPoint = Vector3.Distance(player.position, grapplePoint);

            //the distance the grapple will try to keep from grapple point
            joint.maxDistance= distanceFromPoint * 0.8f;
            joint.minDistance = distanceFromPoint * 0.25f;

            //values that affect the gun
            joint.spring = 4.5f;
            joint.damper = 7f;
            joint.massScale = 4.5f;

            lr.positionCount = 2;
        }
    }

    void DrawRope() 
    {
        //if not grappling, dont draw rope
        if (!joint) return;
        lr.SetPosition(0, gunTip.position);
        lr.SetPosition(0, grapplePoint);
    }
    //called after update
    
    void StopGrapple()
    {
        lr.positionCount = 0;
        Destroy(joint);
    }

    public bool IsGrappling() 
    {
        return joint ==null;
    }

    public Vector3 GetGrapplePoint() 
    {
        return grapplePoint;
    }
}
