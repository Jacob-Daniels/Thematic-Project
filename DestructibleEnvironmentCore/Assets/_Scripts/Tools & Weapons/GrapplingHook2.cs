using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GrapplingHook2 : MonoBehaviour
{
    [SerializeField] private PlayerMovement _controller;
    [SerializeField] private Transform _grapplingHook;
    [SerializeField] private Transform _handPos;
    [SerializeField] private Transform _playerBody;
    [SerializeField] private LayerMask _grappleLayer;
    [SerializeField] private float _maxGrappleDistance;
    [SerializeField] private float hookSpeed;
    [SerializeField] private Vector3 _offset;

    private bool isShooting, isGrappling;
    private Vector3 _hookPoint;
    // Start is called before the first frame update
    void Start()
    {
        isShooting = false;
        isGrappling = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (_grapplingHook.parent == _handPos)
        {
            _grapplingHook.localPosition = new Vector3(-0.6386f, -0.0246f, 0.0151f);
            _grapplingHook.localRotation = Quaternion.Euler(new Vector3(0,0,0));
        }
        if (Input.GetMouseButtonDown(1)) 
        {
            ShootHook();
        }
        if (isGrappling) 
        {
            _grapplingHook.position = Vector3.Lerp(_grapplingHook.position, _hookPoint, hookSpeed * Time.deltaTime);
            if (Vector3.Distance(_grapplingHook.position, _hookPoint) < 0.5f) 
            {
                _controller.enabled = false;
                _playerBody.position = Vector3.Lerp(_playerBody.position, _hookPoint - _offset, hookSpeed * Time.deltaTime);
                if (Vector3.Distance(_playerBody.position, _hookPoint - _offset) < 0.5f)
                {
                    _controller.enabled = true;
                    
                    isGrappling = false;
                    _grapplingHook.SetParent(_handPos);
                }
            }        
        }
    }

    private void ShootHook() 
    {
        if (isShooting || isGrappling) return;

        isShooting = true;
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit, _maxGrappleDistance, _grappleLayer)) 
        {
            _hookPoint = hit.point;
            isGrappling = true;
            _grapplingHook.parent = null;
            _grapplingHook.LookAt(_hookPoint);
            print("Hit!");
        }
        isShooting = false;
    }
}
