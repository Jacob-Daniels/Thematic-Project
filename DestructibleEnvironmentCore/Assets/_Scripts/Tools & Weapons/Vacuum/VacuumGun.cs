using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VacuumGun : MonoBehaviour
{
    [SerializeField] private MeshCollider meshCollider;

    private void Update()
    {
        // Get input for vacuum gun
        if (Input.GetMouseButtonDown(1))
        {
            meshCollider.enabled = true;
        }
        if (Input.GetMouseButtonUp(1))
        {
            meshCollider.enabled = false;
        }
    }
}
