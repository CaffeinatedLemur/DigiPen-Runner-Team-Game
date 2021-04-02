/*******************************************
 * Authors: Thomas A
 * Date: 4/2/2021
 * Desc: Handles actions when the player picks up the dino
 * ****************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DinoPickup : MonoBehaviour
{
    private PlayerHealthHandler playerHealthHandler;    //health script
    private void Start()
    {
        //get the health script
        playerHealthHandler = FindObjectOfType<PlayerHealthHandler>();
        //kill other dinos in current scene
        if (FindObjectsOfType<DinoPickup>().Length > 1)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //make sure the player picked it up
        if (collision.gameObject.CompareTag("Player"))
        {
            //add dino
            playerHealthHandler.AddDino(true);
        }
        //kill it
        Destroy(gameObject);
    }
}
