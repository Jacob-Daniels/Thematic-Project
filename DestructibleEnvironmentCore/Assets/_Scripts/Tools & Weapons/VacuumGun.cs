using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VacuumGun : MonoBehaviour
{
    [SerializeField] private MeshFilter meshFilter;

    [Header("Gun Properties:")]
    [SerializeField] private float vacuumSpeed = 20.0f;
    public float GetVacuumSpeed() { return vacuumSpeed; }

    [Header("Vacuum Area Properties:")]
    [Range(-1.0f, -20.0f)] [SerializeField] private float distanceFromGun = -5.0f;
    [SerializeField] private float startPoint = 0.0f;
    [Range(1.0f, 20.0f)] [SerializeField] private float coneWidth = 2.0f;
    [Range(1.0f, 20.0f)] [SerializeField] private float coneHeight = 2.0f;

    [Header("Mesh Properties:")]
    [SerializeField] private Vector3[] coneVertices;
    [SerializeField] private Vector2[] coneUVs;
    [SerializeField] private int[] coneTriangles;

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
        coneVertices = new Vector3[17];
        //coneUVs = new Vector2[10];
        coneTriangles = new int[48];

        // Vertices
        coneVertices[1] = new Vector3(distanceFromGun, startPoint, startPoint);                                        // 1
        coneVertices[2] = new Vector3(distanceFromGun, startPoint, coneWidth);                                         // 2
        coneVertices[3] = new Vector3(distanceFromGun, -coneHeight + (coneHeight / 4), coneWidth - (coneWidth / 4));   // 3
        coneVertices[4] = new Vector3(distanceFromGun, -coneHeight, startPoint);                                       // 4
        coneVertices[5] = new Vector3(distanceFromGun, -coneHeight + (coneHeight / 4), -coneWidth + (coneWidth / 4));  // 5
        coneVertices[6] = new Vector3(distanceFromGun, startPoint, -coneWidth);                                        // 6
        coneVertices[7] = new Vector3(distanceFromGun, coneHeight - (coneHeight / 4), -coneWidth + (coneWidth / 4));   // 7
        coneVertices[8] = new Vector3(distanceFromGun, coneHeight, startPoint);                                        // 8
        coneVertices[9] = new Vector3(distanceFromGun, coneHeight - (coneHeight / 4), coneWidth - (coneWidth / 4));    // 9

        // Vertices Starting points
        coneVertices[0] = new Vector3(startPoint, startPoint + (transform.localScale.y / 2), startPoint);                                      // 0 (Starting point at gun)
        coneVertices[10] = new Vector3(startPoint, startPoint + (transform.localScale.y / 2), startPoint + (transform.localScale.z / 2));      // 10
        coneVertices[11] = new Vector3(startPoint, startPoint, startPoint + (transform.localScale.z / 2));                                     // 11
        coneVertices[12] = new Vector3(startPoint, startPoint - (transform.localScale.y / 2), startPoint + (transform.localScale.z / 2));      // 12
        coneVertices[13] = new Vector3(startPoint, startPoint - (transform.localScale.y / 2), startPoint);                                     // 13
        coneVertices[14] = new Vector3(startPoint, startPoint - (transform.localScale.y / 2), startPoint - (transform.localScale.z / 2));      // 14
        coneVertices[15] = new Vector3(startPoint, startPoint, startPoint - (transform.localScale.z / 2));                                     // 15
        coneVertices[16] = new Vector3(startPoint, startPoint + (transform.localScale.y / 2), startPoint - (transform.localScale.z / 2));      // 17

        // Triangles (Assign in a clockwise order to display front face)
        // 1
        coneTriangles[0] = 11;
        coneTriangles[1] = 2;
        coneTriangles[2] = 3;
        // 2
        coneTriangles[3] = 12;
        coneTriangles[4] = 3;
        coneTriangles[5] = 4;
        // 3
        coneTriangles[6] = 13;
        coneTriangles[7] = 4;
        coneTriangles[8] = 5;
        // 4
        coneTriangles[9] = 14;
        coneTriangles[10] = 5;
        coneTriangles[11] = 6;
        // 5
        coneTriangles[12] = 15;
        coneTriangles[13] = 6;
        coneTriangles[14] = 7;
        // 6
        coneTriangles[15] = 16;
        coneTriangles[16] = 7;
        coneTriangles[17] = 8;
        // 7
        coneTriangles[18] = 0;
        coneTriangles[19] = 8;
        coneTriangles[20] = 9;
        // 8
        coneTriangles[21] = 10;
        coneTriangles[22] = 9;
        coneTriangles[23] = 2;
        // BASE TRIANGLES
        // 1
        coneTriangles[24] = 1;
        coneTriangles[25] = 3;
        coneTriangles[26] = 2;
        // 2
        coneTriangles[27] = 1;
        coneTriangles[28] = 4;
        coneTriangles[29] = 3;
        // 3
        coneTriangles[30] = 1;
        coneTriangles[31] = 5;
        coneTriangles[32] = 4;
        // 4
        coneTriangles[33] = 1;
        coneTriangles[34] = 6;
        coneTriangles[35] = 5;
        // 5
        coneTriangles[36] = 1;
        coneTriangles[37] = 7;
        coneTriangles[38] = 6;
        // 6
        coneTriangles[39] = 1;
        coneTriangles[40] = 8;
        coneTriangles[41] = 7;
        // 7
        coneTriangles[42] = 1;
        coneTriangles[43] = 9;
        coneTriangles[44] = 8;
        // 8
        coneTriangles[45] = 1;
        coneTriangles[46] = 2;
        coneTriangles[47] = 9;

        // Assign mesh to meshfilter and mesh collider
        mesh.vertices = coneVertices;
        mesh.uv = coneUVs;
        mesh.triangles = coneTriangles;
        gameObject.GetComponent<MeshCollider>().sharedMesh = meshFilter.mesh;
    }
}
