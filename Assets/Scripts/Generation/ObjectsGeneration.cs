using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectsGeneration : MonoBehaviour
{
    [SerializeField] private GameObject[] objects;
    [SerializeField] private int[] countObjects;

    private Transform[] objectsTransform;
    private int[] objectsID;
    private int totalObjects;

    

    public void CreateTreeInstance(float[,] heightMap)
    {
        countTotalObjects();
        objectsTransform = new Transform[totalObjects];
        objectsID = new int[totalObjects];

        int width = heightMap.GetLength(0);
        int height = heightMap.GetLength(1);

        int i = 0;
        for (int x = 0; x < width; x += 1)
        {
            for (int z = 0; z < height; z += 1)
            {
                if (heightMap[x, z] > 0.1 && i < 100)
                {
                    
                    switch (Random.Range(0, 20))
                    {
                        case 7:
                            {
                                Vector3 onjectPosition = new Vector3(transform.position.x + x, heightMap[x, z] + transform.position.y, transform.position.z + z);
                                i++;
                                Instantiate(objects[0], onjectPosition, Quaternion.identity, transform);
                                break;
                            }
                        case 8:
                            {
                                Vector3 onjectPosition = new Vector3(transform.position.x + x, heightMap[x, z] + transform.position.y, transform.position.z + z);
                                i++;
                                Instantiate(objects[1], onjectPosition, Quaternion.identity, transform);

                                break;
                            }
                        case 9:
                            {
                                Vector3 onjectPosition= new Vector3(transform.position.x + x, heightMap[x, z] + transform.position.y, transform.position.z + z);
                                i++;
                                Instantiate(objects[2], onjectPosition, Quaternion.identity, transform);

                                break;
                            }
                    }
                }
            }
        }
    }

    private void countTotalObjects()
    {
        totalObjects = 0;
        for (int i = 0; i < countObjects.Length; i++)
        {
            totalObjects += countObjects[i];
        }
    }
}
