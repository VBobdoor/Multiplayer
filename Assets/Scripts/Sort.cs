using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sort : MonoBehaviour
{
    private void Start()
    {
        int[] array = new int[200];
        for (int i = 0; i < array.Length; i++)
        {
            array[i] = Random.Range(-100, 100);
        }
        for (int i = 0; i < array.Length; i++)
        {
            Debug.Log(array[i]);
        }
        int min = 101;
        int k = 0;
        for (int i = 0; i < array.Length; i++)
        {
            for (int j = i; j < array.Length; j++)
            {
                if (min > array[j])
                {
                    min = array[j];
                    k = j;
                }



            }
            array[k] = array[i];
            array[i] = min;
            min = 101;

        }

        for (int i = 0; i < array.Length; i++)
        {
            Debug.Log(array[i]);
        }
    }
}
