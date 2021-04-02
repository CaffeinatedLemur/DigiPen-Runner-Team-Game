using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerHealthHandler : MonoBehaviour
{
    [SerializeField] int maxHealth = 3;
    [SerializeField] public static int playerHealth = 3;
    [SerializeField] public static bool isInvulnerable = false;
    [SerializeField] int dinoHealth = 0;
    [SerializeField] Image[] currentHearts;
    [SerializeField] Image[] missingHearts;
    [SerializeField] Image[] shieldsHearts;
    [SerializeField] Image dinoHeart;

    [SerializeField] GameObject dinoBoiPlayer;

    public void Start()
    {
        UpdateUI(playerHealth);
        dinoBoiPlayer = FindObjectOfType<DinoFollower>().gameObject;
        dinoBoiPlayer.gameObject.GetComponent<SpriteRenderer>().enabled = false;
        for (int i = 0; i < maxHealth; i++)
        {
            missingHearts[i].gameObject.SetActive(false);
        }
    }

    public void AddHealth(int healthMod)
    {
        playerHealth += healthMod;
        if (playerHealth >= maxHealth)
            playerHealth = maxHealth;
        UpdateUI(playerHealth);
    }
    public void AddDino(bool add)
    {
        if (add)
        {
            dinoHealth = 1;
            dinoBoiPlayer.gameObject.GetComponent<SpriteRenderer>().enabled = true;
            if (dinoHealth >= 1)
                dinoHealth = 1;
        }
        else
        {
            dinoHealth = 0;
            dinoBoiPlayer.gameObject.GetComponent<SpriteRenderer>().enabled = false;
        }
        UpdateUI(playerHealth);
    }
    public void SubtractHealth(int healthMod)
    {
        if (!isInvulnerable)
        {
            if (dinoHealth > 0)
                AddDino(false);
            else
            {
                missingHearts[playerHealth - 1].gameObject.SetActive(true);
                playerHealth -= healthMod;
            }
        }
        UpdateUI(playerHealth);
    }
    public void UpdateUI(int currentHealth)
    {
        /*
        for (int i = 0; i < maxHealth; i++)
        {
            print(missingHearts[i].gameObject.activeSelf);
            if (i <= currentHealth)
            {
                missingHearts[i].gameObject.SetActive(false);
            }
            else
                missingHearts[i].gameObject.SetActive(true);

        }
        */
        for (int i = 0; i < maxHealth; i++)
        {
            //missingHearts[i].gameObject.SetActive(false);
            for (int p = maxHealth; p < currentHealth; p++)
            {
                missingHearts[p].gameObject.SetActive(true);
            }
        }



        if (dinoHealth == 1)
            currentHearts[3].gameObject.SetActive(true);
        else
            currentHearts[3].gameObject.SetActive(false);

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
        UpdateUI(playerHealth);

        if (playerHealth <= 0)
        {
            SceneManager.LoadScene(2);
        }
    }
}
