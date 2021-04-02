/*******************************************
 * Authors: Thomas A
 * Date: 4/2/2021
 * Desc: Spawns platforms, powerups, and enemies
 * ****************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    [SerializeField] public GameObject parentObj; //parent obj to instatiate everything under
    [SerializeField] Transform playerTransform; //position of player

    [SerializeField] GameObject[] powerUps; //array of powerup options
    [SerializeField] GameObject[] enemyBois; //array of enemy options
    [SerializeField] GameObject[] platforms; //array of platform options
    private Vector3[,] platformPositions = new Vector3[25, 10]; //array of possible positions for things to spawn in
    private Vector2 randPos; //default pos for instatiation

    // Start is called before the first frame update
    void Start()
    {
        //create the array
        for (int i = 0; i < 25; i++)
        {
            for (int p = 0; p < 10; p++)
            {
                platformPositions[i, p] = new Vector3(i, p, 2);
            }
        }
        //spawn starting platforms
        for (int i = 0; i < 20; i++)
            SpawnPlatform();
    }
    public void SpawnPlatform()
    {
        GameObject temp; //temp obj to hold the new platform
        int xPos = Random.Range(0, 25); //find and store a random x position
        int yPos = Random.Range(0, 10); //find and store a random y position
        //1 in 4 chance to spawn a broken platform instead of a normal one
        if (Mathf.RoundToInt(Random.Range(0, 4)) == 0)
        {
            //Instantiate and child the platform, position on the random pos
            temp = Instantiate(platforms[1], randPos, Quaternion.identity);
            temp.transform.parent = parentObj.transform;
            temp.transform.localPosition = platformPositions[xPos, yPos];
        }
        else
        {
            //Instantiate and child the platform, position on the random pos
            temp = Instantiate(platforms[0], randPos, Quaternion.identity);
            temp.transform.parent = parentObj.transform;
            temp.transform.localPosition = platformPositions[xPos, yPos];

        }
        //1 in 16 chance for a powerup to spawn
        if (Mathf.RoundToInt(Random.Range(0,16)) == 0)
        {
            SpawnPowerup();
        }
        //1 in 10 chance for an enemy to spawn
        if (Mathf.RoundToInt(Random.Range(0, 10)) == 0)
        {
            SpawnEnemy();
        }
    }

    public void SpawnPowerup()
    {
        //Instantiate and child the powerup, position on the random pos
        GameObject temp = Instantiate(powerUps[Mathf.RoundToInt(Random.Range(0,powerUps.Length))], randPos, Quaternion.identity);
        temp.transform.parent = parentObj.transform;
        temp.transform.localPosition = platformPositions[Random.Range(0, 25), Random.Range(0, 10)];
    }
    public void SpawnEnemy()
    {
        //Instantiate and child the enemy, position on the random pos
        GameObject temp = Instantiate(enemyBois[Mathf.RoundToInt(Random.Range(0, enemyBois.Length))], randPos, Quaternion.identity);
        temp.transform.parent = parentObj.transform;
        temp.transform.localPosition = platformPositions[Random.Range(0, 25), Random.Range(0, 10)];
    }
}
