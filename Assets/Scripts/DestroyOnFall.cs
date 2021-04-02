/*******************************************
 * Authors: Thomas A
 * Date: 4/2/2021
 * Desc: Kills the player if they hit an obstacle
 * ****************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DestroyOnFall : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //make sure you hit the right thing
        if (collision.CompareTag("Obstacle"))
        {
            //if you did, kill the player and load death scene
            Destroy(gameObject);
            SceneManager.LoadScene(2);
        }
    }
}
