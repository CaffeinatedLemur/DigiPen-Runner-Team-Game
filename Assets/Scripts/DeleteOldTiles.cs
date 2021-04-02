/*******************************************
 * Authors: Thomas A
 * Date: 4/2/2021
 * Desc: Deletes old uneeded platfomrs and generates new ones to replace as the player moved up./
 * ****************************************/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteOldTiles : MonoBehaviour
{
    [SerializeField] GameObject player; //player
    [SerializeField] Transform playerTransform; //transform of player
    [SerializeField] GameObject platformParentObj; //the parent object that holds that wave of platforms
    [SerializeField] GameObject platformParentObjPrefab; //prefab of a new parent obj to instantiate
    [SerializeField] GameObject killBox; //killbox that kills the player if they fall
    private Vector3 updatedParentPos; //vecotr3 to hold the new position of where to instantiate a new parent
    private PlatformSpawner platformSpawner; //platform spawner script

    private float autoSpawnCD = 10; //cooldown before game automaticallly spawns platforms when player is not moving, so as to not let player get stuck
    private float timer = 0; //timer in between spawns
    // Start is called before the first frame update
    void Start()
    {
        platformSpawner = FindObjectOfType<PlatformSpawner>(); //find the generator
        updatedParentPos = new Vector3(-12.1f, 0, 0); //create a vector3 to update the positions of the objs
    }

    // Update is called once per frame
    void Update()
    {
        //update timer
        timer += Time.deltaTime;
        //Create an array of all the platforms in the parent obj
        Transform[] previousPlatforms = new Transform[platformParentObj.transform.childCount];
        //assign the values in the array to the transform of each platform childed to its parent
        for (int i = 0; i < platformParentObj.transform.childCount; i++)
        {
            previousPlatforms[i] = platformParentObj.transform.GetChild(i).GetComponent<Transform>();
        }
        //loop throguh the old platforms
        for (int i = 0; i < previousPlatforms.Length; i++)
        {
            //check if the player has moved away from a platform
            if(previousPlatforms[i].position.y < (playerTransform.position.y - 5))
            {
                //if they have, update the vecor3 to match the player's current position
                updatedParentPos = new Vector3(-12.1f, platformParentObj.transform.position.y + 6, 0);
                //instantiate a new parent
                GameObject temp = Instantiate(platformParentObjPrefab, updatedParentPos, Quaternion.identity);

                //update variables to match new versions
                platformParentObj = temp;
                platformSpawner.parentObj = temp;
               //get rid of the old thing
                Destroy(previousPlatforms[i].gameObject);
                //make 10 new platforms
                for (int p = 0; p < 10; p++)
                {
                    platformSpawner.SpawnPlatform();
                }
                //move the killbox up
                Vector3 updatedKillboxPos = new Vector3(0, playerTransform.position.y - 15, 0);
                killBox.transform.position = updatedKillboxPos;
                //reset spawn timer
                timer = 0;
            }
        }
        //check if the player has not cuased new platforms to generate recently
        if (timer > autoSpawnCD)
        {
            //if they havnt, it means they are likly stuck, so we should spawn new platforms to help them up
            for (int p = 0; p < 10; p++)
            {
                platformSpawner.SpawnPlatform();
                //reset the cooldown
                timer = 0;
            }
        }
        //update the array
        previousPlatforms = platformParentObj.GetComponentsInChildren<Transform>();
    }
}
