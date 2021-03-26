using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteOldTiles : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] Transform playerTransform;
    [SerializeField] GameObject platformParentObj;

    private PlatformSpawner platformSpawner;
    // Start is called before the first frame update
    void Start()
    {
        platformSpawner = FindObjectOfType<PlatformSpawner>();
    }

    // Update is called once per frame
    void Update()
    {
        Transform[] previousPlatforms = platformParentObj.GetComponentsInChildren<Transform>();
        for (int i = 0; i < previousPlatforms.Length; i++)
        {
            if(previousPlatforms[i].position.y < (playerTransform.position.y - 10))
            {
                Destroy(previousPlatforms[i]);
                platformSpawner.SpawnPlatform(playerTransform);
            }
        }
    }
}
