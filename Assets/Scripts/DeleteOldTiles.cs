using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteOldTiles : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] Transform playerTransform;
    [SerializeField] GameObject platformParentObj;
    [SerializeField] GameObject platformParentObjPrefab;
    [SerializeField] GameObject killBox;
    private Vector3 updatedParentPos;
    private PlatformSpawner platformSpawner;
    // Start is called before the first frame update
    void Start()
    {
        platformSpawner = FindObjectOfType<PlatformSpawner>();
        updatedParentPos = new Vector3(-12.1f, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        
        //Transform[] previousPlatforms = platformParentObj.GetComponentsInChildren<Transform>();
        Transform[] previousPlatforms = new Transform[platformParentObj.transform.childCount];
        for (int i = 0; i < platformParentObj.transform.childCount; i++)
        {
            previousPlatforms[i] = platformParentObj.transform.GetChild(i).GetComponent<Transform>();
        }
        for (int i = 0; i < previousPlatforms.Length; i++)
        {
            if(previousPlatforms[i].position.y < (playerTransform.position.y - 5))
            {
                updatedParentPos = new Vector3(-12.1f, platformParentObj.transform.position.y + 6, 0);
                GameObject temp = Instantiate(platformParentObjPrefab, updatedParentPos, Quaternion.identity);


                platformParentObj = temp;
                platformSpawner.parentObj = temp;
                //previousPlatforms[i].gameObject.SetActive(false);
               
                Destroy(previousPlatforms[i].gameObject);

                for (int p = 0; p < 10; p++)
                    platformSpawner.SpawnPlatform();
                Vector3 updatedKillboxPos = new Vector3(0, playerTransform.position.y - 10, 0);
                killBox.transform.position = updatedKillboxPos;
            }
        }
        previousPlatforms = platformParentObj.GetComponentsInChildren<Transform>();
    }
}
