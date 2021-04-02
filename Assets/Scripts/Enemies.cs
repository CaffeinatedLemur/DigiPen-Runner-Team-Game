/*******************************************
 * Authors: Thomas A
 * Date: 4/2/2021
 * Desc: Handles actions when the player hits an enemy
 * ****************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemies : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //make sure the player hit them
        if (collision.gameObject.CompareTag("Player"))
        {
            //remove a health
            collision.gameObject.GetComponent<PlayerHealthHandler>().SubtractHealth(1);
            //remove the enemy
            Destroy(gameObject);
        }
    }
}
