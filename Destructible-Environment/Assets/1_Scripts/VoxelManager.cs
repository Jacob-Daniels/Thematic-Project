using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Mathematics;
using UnityEditor;

public class VoxelManager : MonoBehaviour
{
    public GameObject voxelPrefab;
    public Transform voxelParent;
    [Header("Voxel Properties:")]
    public Vector3Int dimentions;
    byte[,,] voxels;
    public float noiseScale;

    private void Awake()
    {
        voxels = new byte[dimentions.x, dimentions.y, dimentions.z];
        GenerateNoise();
        GenerateMesh();
    }

    private void GenerateNoise()
    {
        // Create a 3D grid of voxels from the given dimentions
        for (int x = 0; x < dimentions.x; x++)
        {
            for (int y = 0; y < dimentions.y; y++)
            {
                for (int z = 0; z < dimentions.z; z++)
                {
                    // Set value of noise float to 1 or 0 and populate array
                    voxels[x, y, z] = noise.snoise(new float3((float)x, (float)y, (float)z) / noiseScale) >= 0 ? (byte)1 : (byte)0;
                    // Instantiate voxel object
                    if (voxels[x, y, z] == 1)
                    {
                        GameObject voxelObj = Instantiate(voxelPrefab, new Vector3(x, y, z), quaternion.identity);
                        voxelObj.transform.parent = voxelParent;
                    }
                }
            }
        }
    }

    private void GenerateMesh()
    {
        List<Vector3> Verticies = new List<Vector3>();
        List<int> Triangles = new List<int>();
        List<Vector2> Uvs = new List<Vector2>();
        // Generate a mesh on a face that is visible
        for (int x = 1; x < dimentions.x - 1; x++)
        {
            for (int y = 1; y < dimentions.y - 1; y++)
            {
                for (int z = 1; z < dimentions.z - 1 ; z++)
                {
                    Vector3[] vertPos = new Vector3[8]
                    {
                        new Vector3(-1,1,-1), new Vector3(-1, 1, 1),
                        new Vector3(1, 1, 1), new Vector3(1, 1, -1),
                        new Vector3(-1, -1, -1), new Vector3(-1, -1, 1),
                        new Vector3(1, -1, 1), new Vector3(1, -1, -1)
                    };

                    // Array of sides to check faces
                    int[,] Faces = new int[6, 9]
                    {
                       {0, 1, 2, 3, 0, 1, 0, 0, 0},     // Top
                       {7, 6, 5, 4, 0, -1, 0, 1, 0},    // Bottom
                       {2, 1, 5, 6, 0, 0, 1, 1, 1},     // Right
                       {0, 3, 7, 4, 0, 0, -1, 1, 1},     // Left
                       {3, 2, 6, 7, 1, 0, 0, 1, 1},     // Front
                       {1, 0, 4, 5, -1, 0, 0, 1, 1},    // Back
                    };

                    if (voxels[x, y, z] == 1)
                        for (int o = 0; o < 6; o++)
                            if (voxels[x + Faces[o, 4], y + Faces[o, 5], z + Faces[o, 6]] == 0)
                                AddQuad(o, Verticies.Count);

                    void AddQuad(int facenum, int v)
                    {
                        // Add Mesh
                        for (int i = 0; i < 4; i++) Verticies.Add(new Vector3(x, y, z) + vertPos[Faces[facenum, i]] / 2f);
                        Triangles.AddRange(new List<int>() { v, v + 1, v + 2, v, v + 2, v + 3 });

                        // Add uvs
                        Vector2 bottomleft = new Vector2(Faces[facenum, 7], Faces[facenum, 8]) / 2f;

                        Uvs.AddRange(new List<Vector2>() { bottomleft + new Vector2(0, 0.5f), bottomleft + new Vector2(0.5f, 0.5f), bottomleft + new Vector2(0.5f, 0), bottomleft });
                    }
                }
            }
        }
        // Assign values to mesh component
        GetComponent<MeshFilter>().mesh = new Mesh()
        {
            name = "Voxel Mesh",
            vertices = Verticies.ToArray(),
            triangles = Triangles.ToArray(),
            uv = Uvs.ToArray()
        };
        // Create Collision Mesh
        GetComponent<MeshCollider>().sharedMesh = GetComponent<MeshFilter>().mesh;
    }
}
