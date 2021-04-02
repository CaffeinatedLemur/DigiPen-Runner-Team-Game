/*******************************************
 * Authors: Thomas A. 
 * Date: 4/2/2021
 * Desc: Handles player health and health UI
 * ****************************************/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerHealthHandler : MonoBehaviour
{
    [SerializeField] int maxHealth = 3; //max health of the player
    [SerializeField] public static int playerHealth = 3; //current health of the player
    [SerializeField] public static bool isInvulnerable = false; //wether or not the player in invulnerable
    [SerializeField] int dinoHealth = 0; //wether or not the palyer has the extra heart from the dino
    //arrrays to store various UI elements
    [SerializeField] Image[] currentHearts; 
    [SerializeField] Image[] missingHearts;
    [SerializeField] Image[] shieldsHearts;
    [SerializeField] Image dinoHeart; //the dino heart <3
    [SerializeField] GameObject dinoBoiPlayer; //the dino childed to player
    public AudioClip ac; //audioclip to play on damaged
    public void Start()
    {
        UpdateUI(playerHealth); //upadte the UI right away
        dinoBoiPlayer = FindObjectOfType<DinoFollower>().gameObject; //find the dino follower script
        dinoBoiPlayer.gameObject.GetComponent<SpriteRenderer>().enabled = false; //get the sprite renderer of the dino pet
        //reset all hearts
        for (int i = 0; i < maxHealth; i++)
        {
            missingHearts[i].gameObject.SetActive(false);
        }
    }

    public void AddHealth(int healthMod)
    {
        //add health equal to given health to be added
        playerHealth += healthMod;
        //if you are above the max, reset to max
        if (playerHealth >= maxHealth)
            playerHealth = maxHealth;
        //update the UI
        missingHearts[playerHealth - 1].gameObject.SetActive(false);
        UpdateUI(playerHealth);
    }
    public void AddDino(bool add)
    {
        //wether to add of remove the dino heart and dino
        if (add)
        {
            //if you shuld, set dino health to 1
            dinoHealth = 1;
            //turn on the dino
            dinoBoiPlayer.gameObject.GetComponent<SpriteRenderer>().enabled = true;
            //cap the dinohealth at 1
            if (dinoHealth >= 1)
                dinoHealth = 1;
        }
        else
        {
            //otherwise, kill the dino and reset the health
            dinoHealth = 0;
            dinoBoiPlayer.gameObject.GetComponent<SpriteRenderer>().enabled = false;
        }
        //update the ui to match new status
        UpdateUI(playerHealth);
    }
    public void SubtractHealth(int healthMod)
    {
        //only subtract if player inst invulnerable
        if (!isInvulnerable)
        {
            //if the player has a dino, instead kill the dino :(
            if (dinoHealth > 0)
                AddDino(false);
            else
            {
                //otherwise, subtract from health and update the UI
                missingHearts[playerHealth - 1].gameObject.SetActive(true);
                playerHealth -= healthMod;
            }
            //player the damaged sound effect
            GetComponent<AudioSource>().PlayOneShot(ac);
        }
        //update UI to match new status
        UpdateUI(playerHealth);
    }
    public void UpdateUI(int currentHealth)
    {
        //turn dino heart on or off
        if (dinoHealth == 1)
            currentHearts[3].gameObject.SetActive(true);
        else
            currentHearts[3].gameObject.SetActive(false);
        //add shield overlay if you are invulnerable
        if (isInvulnerable)
        {
            for (int i = 0; i < currentHealth; i++)
            {
                shieldsHearts[i].gameObject.SetActive(true);
            }

            if (dinoHealth == 1)
                shieldsHearts[3].gameObject.SetActive(true);
            else
                shieldsHearts[3].gameObject.SetActive(false);
        }
        //otherwise turn them off
        else
        {
            for (int i = 0; i < maxHealth; i++)
            {
                shieldsHearts[i].gameObject.SetActive(false);
            }

            if (dinoHealth == 1)
                shieldsHearts[3].gameObject.SetActive(false);
            else
                shieldsHearts[3].gameObject.SetActive(false);
        }
    }


    private void Update()
    {
        //update teh UI
        UpdateUI(playerHealth);
        //kill player and end run if the player dies
        if (playerHealth <= 0)
        {
            playerHealth = maxHealth;
            isInvulnerable = false;
            UpdateUI(playerHealth);
            SceneManager.LoadScene(2);
        }
    }
}
