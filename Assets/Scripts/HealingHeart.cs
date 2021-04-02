/*******************************************
 * Authors: Thomas A. Sounds added by Mario E.
 * Date: 4/2/2021
 * Desc: Handles actions when the player picks up a heart
 * ****************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealingHeart : MonoBehaviour
{
    
    private PlayerHealthHandler playerHealthHandler;//health script
    public AudioClip ac; //soundclip to play on pickup
    // Start is called before the first frame update
    void Start()
    {
        //find the health script
        playerHealthHandler = FindObjectOfType<PlayerHealthHandler>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //make sure it's the player
        if (collision.gameObject.CompareTag("Player"))
        {
            //add health 
            playerHealthHandler.AddHealth(1);
            //play the pickup sound
            collision.GetComponent<AudioSource>().PlayOneShot(ac);
            //kill the heart
            Destroy(gameObject);
            
        }
        
    }
}
