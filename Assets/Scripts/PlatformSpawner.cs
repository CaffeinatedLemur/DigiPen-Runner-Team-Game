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
                platformPositions[i, p] = new Vector3(i, p, -10);
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
        /*
        BoxCollider2D[] previousPlatforms = GetComponentsInChildren<BoxCollider2D>();
        randPos = GenerateRandom();
        GameObject temp = Instantiate(basicPlatform, randPos, Quaternion.identity);
        temp.transform.parent = parentObj.transform;

        for (int i = 0; i < previousPlatforms.Length; i++)
        {
            if (temp.GetComponent<BoxCollider2D>().bounds.Intersects(previousPlatforms[i].bounds))
            {
                temp.SetActive(false);
                SpawnPlatform(playerTransform);
            }
        }
        */
    }  

    private static Vector2 GenerateRandom()
    {
        Vector2 randPos;
        randPos.x = Random.Range(-14.5f, 14.5f);
        randPos.y = Random.Range(-2.5f, 2.5f);
        return randPos;
    }

    // Update is called once per frame
    void Update()
    {
        
        
    }
}
