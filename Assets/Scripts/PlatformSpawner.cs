using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    [SerializeField] GameObject basicPlatform;
    [SerializeField] GameObject parentObj;
    [SerializeField] Transform playerTransform;
    

    private Vector2 randPos;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 20; i++)
            SpawnPlatform(playerTransform);
    }

    public void SpawnPlatform(Transform playerTransform)
    {
        GameObject[] previousPlatforms = GetComponentsInChildren<GameObject>();
        randPos = GenerateRandom();
        GameObject temp = Instantiate(basicPlatform, randPos, Quaternion.identity);
        temp.transform.parent = parentObj.transform;

        for (int i = 0; i < previousPlatforms.Length; i++)
        {
            if (temp.GetComponent<BoxCollider2D>().bounds.Intersects(previousPlatforms[i].GetComponent<BoxCollider2D>().bounds))
            {
                Destroy(temp);
                SpawnPlatform(playerTransform);
            }
        }
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
