



using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]
[ExecuteInEditMode]
public class MeshController : MonoBehaviour
{
    int numCellsX = 150;
    int numCellsZ = 150;

    int xSize = 5; 
    int zSize = 5;

    float waterLevel = 0.5f;

    Mesh mesh;
    MeshFilter meshFilter;
    Material material;



    private void Start()
    {
        meshFilter = GetComponent<MeshFilter>();

        //make sure not to overwrite this mesh by copying, otherwise will destory mesh for all objects of this type!
        mesh = new Mesh(); 
        mesh.name = "Generated Mesh";
        meshFilter.mesh = mesh;

        CalculateTerrain();

        material = GetComponent<MeshRenderer>().sharedMaterial;
        material.SetFloat("_WaterLevel", waterLevel);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            waterLevel = Mathf.Min(1.0f, waterLevel + 0.05f);
            material.SetFloat("_WaterLevel", waterLevel);
        } 
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            waterLevel = Mathf.Max(0.0f, waterLevel - 0.05f);
            material.SetFloat("_WaterLevel", waterLevel);
        }
    }

    private void CalculateTerrain()
    {
        mesh.Clear();


        Vector3[] vertices = new Vector3[(numCellsX + 1) * (numCellsZ + 1)];
        Vector2[] uv = new Vector2[vertices.Length];

        float startX = -xSize / 2.0f;
        float startZ = -zSize / 2.0f;
        float xInc = (float)xSize / (float)numCellsX;
        float zInc = (float)zSize / (float)numCellsZ;

        int idx = 0;
        for (int z = 0; z <= numCellsZ; z++)
        {
            for (int x = 0; x <= numCellsX; x++)
            {
                float zVal = 0f;  //Random.Range(0.0f, 1.0f);
                vertices[idx] = new Vector3(startX + xInc * x, zVal, startZ + zInc * z);
                uv[idx] = new Vector2((float)x / (float)numCellsX, (float)z / (float)numCellsZ);
                idx++;
            }
        }
        mesh.vertices = vertices;
        mesh.uv = uv;

        int[] triangles = new int[numCellsX * numCellsZ * 6];
        int t_idx = 0;
        int v_idx = 0;
        for (int y = 0; y < numCellsZ; y++)
        {
            for (int x = 0; x < numCellsX; x++)
            {
                triangles[t_idx] = v_idx;
                triangles[t_idx + 3] = triangles[t_idx + 2] = v_idx + 1;
                triangles[t_idx + 4] = triangles[t_idx + 1] = v_idx + numCellsX + 1;
                triangles[t_idx + 5] = v_idx + numCellsX + 2;

                v_idx++;
                t_idx += 6;
            }
            v_idx++;
        }
        mesh.triangles = triangles;
        mesh.RecalculateNormals(); //much easier than doing it ourselves!
    }
}
