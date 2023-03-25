using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VacuumMesh : MonoBehaviour
{
    [Header("Mesh Properties:")]
    [SerializeField] private Vector3[] verticies;
    [SerializeField] private Vector2[] uvTextures;
    [SerializeField] private int[] triangles;

    private void Start()
    {
        verticies = new Vector3[4];
        uvTextures = new Vector2[4];
        triangles = new int[6];

        // Create the mesh
        Mesh mesh = new Mesh();
        gameObject.GetComponent<MeshFilter>().mesh = mesh;

        verticies[0] = new Vector3(-1.0f, 0.0f, 1.0f);
        verticies[1] = new Vector3(1.0f, 0.0f, 1.0f);
        verticies[2] = new Vector3(-1.0f, 0.0f, -1.0f);
        verticies[3] = new Vector3(1.0f, 1.0f, -1.0f);

        uvTextures[0] = new Vector2(0.0f, 0.0f);
        uvTextures[1] = new Vector2(1.0f, 0.0f);
        uvTextures[2] = new Vector2(0.0f, 1.0f);
        uvTextures[3] = new Vector2(1.0f, 1.0f);

        triangles[0] = 0;
        triangles[1] = 1;
        triangles[2] = 3;

        triangles[3] = 0;
        triangles[4] = 3;
        triangles[5] = 2;

        mesh.vertices = verticies;
        mesh.uv = uvTextures;
        mesh.triangles = triangles;

        mesh.RecalculateBounds();
        mesh.RecalculateNormals();
        gameObject.GetComponent<MeshCollider>().sharedMesh = gameObject.GetComponent<MeshFilter>().mesh;
    }
}
