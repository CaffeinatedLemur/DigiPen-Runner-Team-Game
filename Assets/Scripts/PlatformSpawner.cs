using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    [SerializeField] GameObject basicPlatform;
    [SerializeField] GameObject parentObj;
    [SerializeField] Transform playerTransform;


    private Vector3[,] platformPositions = new Vector3[25, 10];
    private Vector2 randPos;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 25; i++)
        {
            for (int p = 0; p < 10; p++)
            {
                platformPositions[i, p] = new Vector3(i, p, 2);
            }
        }

        for (int i = 0; i < 20; i++)
            SpawnPlatform(playerTransform);
    }

    public void SpawnPlatform(Transform playerTransform)
    {
        GameObject temp = Instantiate(basicPlatform, randPos, Quaternion.identity);
        temp.transform.parent = parentObj.transform;
        temp.transform.localPosition = platformPositions[Random.Range(0, 25), Random.Range(0, 10)];
    }  
}
