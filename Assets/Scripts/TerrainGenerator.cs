using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainGenerator : MonoBehaviour
{
    [SerializeField] private GameObject tree1;
    [SerializeField] private GameObject tree2;
    [SerializeField] private GameObject tree3;

    [SerializeField] private int depth = 20;
    [SerializeField] private int width = 256;
    [SerializeField] private int height = 256;
    [SerializeField] private float scale = 20f;
    [SerializeField] private int treeCount = 200;
    

    private void Start()
    {
        Terrain terrain = GetComponent<Terrain>();
        terrain.terrainData = GenerateTerrain(terrain.terrainData);
    }

    TerrainData GenerateTerrain(TerrainData terrainData)
    {
        terrainData.heightmapResolution = width + 1;
        
        
        terrainData.size = new Vector3(width, depth, height);
        terrainData.SetHeights(0, 0, GenerateHeights());

        //terrainData.SetTreeInstances(CreateTreeInstance(terrainData), true);
        CreateTreeInstance(terrainData);

        return terrainData;
    }

    float[,] GenerateHeights()
    {
        float[,] heights = new float[width, height];
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                heights[x, y] = CalculateHeight(x, y);
            }
          
        }
        return heights;
    }
    float CalculateHeight(int x, int y)
    {
        float xCoord = (float)x / width * scale;
        float yCoord = (float)y / height * scale;

        return Mathf.PerlinNoise(xCoord, yCoord);
    }

    private TreeInstance[] CreateTreeInstance(TerrainData terrainData)
    {
        TreeInstance[] treeInstance = new TreeInstance[treeCount];
        for ( int i = 0, x = 0; x < 1024; x+=15)
        {
            for (int z = 0; z < 1024; z += 15)
            {
                switch(Random.Range(0, 20))
                {
                    case 7:
                        {
                            treeInstance[i].position = new Vector3(transform.position.x + x, terrainData.GetHeight(x, z) + transform.position.y, transform.position.z + z);

                            Instantiate(tree1, treeInstance[i].position, Quaternion.identity, transform);
                            break;
                        }
                    case 8:
                        {
                            treeInstance[i].position = new Vector3(transform.position.x + x, terrainData.GetHeight(x, z) + transform.position.y, transform.position.z + z);

                            Instantiate(tree2, treeInstance[i].position, Quaternion.identity, transform);

                            break;
                        }
                    case 9:
                        {
                            treeInstance[i].position = new Vector3(transform.position.x + x, terrainData.GetHeight(x, z) + transform.position.y, transform.position.z + z);

                            Instantiate(tree3, treeInstance[i].position, Quaternion.identity, transform);

                            break;
                        }
                }

            }
        }
        return treeInstance;    
    }
}
