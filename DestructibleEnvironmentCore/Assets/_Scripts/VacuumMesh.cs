using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using UnityEngine;

public class VacuumMesh : MonoBehaviour
{
    [SerializeField] private MeshFilter meshFilter;
    [SerializeField] private MeshCollider meshCollider;

    [Header("Vacuum Area Properties:")]
    [Range(-1.0f, -20.0f)] [SerializeField] private float distanceFromGun = -5.0f;
    [SerializeField] private float startPoint = 0.0f;
    [Range(1.0f, 20.0f)] [SerializeField] private float coneWidth = 2.0f;
    [Range(1.0f, 20.0f)] [SerializeField] private float coneHeight = 2.0f;

    [Header("Mesh Properties:")]
    [SerializeField] private Vector3[] coneVerticies;
    [SerializeField] private Vector2[] coneUVs;
    [SerializeField] private int[] coneTriangles;
    [SerializeField] private Vector3[] baseVerticies;
    [SerializeField] private Vector2[] baseUVs;
    [SerializeField] private int[] baseTriangles;

    private void Start()
    {
        CreateConeMesh();
    }

    private void FixedUpdate()
    {
        // Temp (DELETE AFTER TESTING AS IT DOES NOT NEED TO BE CALLED EVERY FRAME TO UPDATE THE MESH)
        CreateConeMesh();
    }

    private void CreateConeMesh()
    {
        // Create mesh
        Mesh mesh = new Mesh();
        meshFilter.mesh = mesh;
        
        // Cone mesh
        coneVerticies = new Vector3[10];
        coneUVs = new Vector2[10];
        coneTriangles = new int[24];

        // Verticies
        coneVerticies[0] = new Vector3(startPoint, startPoint, startPoint);                                             // 0 (Starting point at gun)
        coneVerticies[1] = new Vector3(distanceFromGun, startPoint, startPoint);                                        // 1
        coneVerticies[2] = new Vector3(distanceFromGun, startPoint, coneWidth);                                         // 2
        coneVerticies[3] = new Vector3(distanceFromGun, -coneHeight + (coneHeight / 4), coneWidth - (coneWidth / 4));   // 3
        coneVerticies[4] = new Vector3(distanceFromGun, -coneHeight, startPoint);                                       // 4
        coneVerticies[5] = new Vector3(distanceFromGun, -coneHeight + (coneHeight / 4), -coneWidth + (coneWidth / 4));  // 5
        coneVerticies[6] = new Vector3(distanceFromGun, startPoint, -coneWidth);                                        // 6
        coneVerticies[7] = new Vector3(distanceFromGun, coneHeight - (coneHeight / 4), -coneWidth + (coneWidth / 4));   // 7
        coneVerticies[8] = new Vector3(distanceFromGun, coneHeight, startPoint);                                        // 8
        coneVerticies[9] = new Vector3(distanceFromGun, coneHeight - (coneHeight / 4), coneWidth - (coneWidth / 4));    // 9

        // Triangles (Assign in a clockwise order to display front face)
        // 1
        coneTriangles[0] = 0;
        coneTriangles[1] = 2;
        coneTriangles[2] = 3;
        // 2
        coneTriangles[3] = 0;
        coneTriangles[4] = 3;
        coneTriangles[5] = 4;
        // 3
        coneTriangles[6] = 0;
        coneTriangles[7] = 4;
        coneTriangles[8] = 5;
        // 4
        coneTriangles[9] = 0;
        coneTriangles[10] = 5;
        coneTriangles[11] = 6;
        // 5
        coneTriangles[12] = 0;
        coneTriangles[13] = 6;
        coneTriangles[14] = 7;
        // 6
        coneTriangles[15] = 0;
        coneTriangles[16] = 7;
        coneTriangles[17] = 8;
        // 7
        coneTriangles[18] = 0;
        coneTriangles[19] = 8;
        coneTriangles[20] = 9;
        // 8
        coneTriangles[21] = 0;
        coneTriangles[22] = 9;
        coneTriangles[23] = 2;

        mesh.vertices = coneVerticies;
        mesh.uv = coneUVs;
        mesh.triangles = coneTriangles;

        // Base mesh

    }
}
