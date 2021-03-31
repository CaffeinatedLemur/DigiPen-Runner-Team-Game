using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthHandler : MonoBehaviour
{
    [SerializeField] int maxHealth = 4;
    [SerializeField] public static int playerHealth = 3;
    [SerializeField] public static bool isInvulnerable = false;

    [SerializeField] Image[] currentHearts;
    [SerializeField] Image[] missingHearts;

    public void Start()
    {
        UpdateUI(playerHealth);
    }


    public void AddHealth(int healthMod)
    {
        
        playerHealth += healthMod;
        if (playerHealth >= maxHealth)
            playerHealth = maxHealth;
        UpdateUI(playerHealth);
    }
    public void SubtractHealth(int healthMod)
    {
        if (!isInvulnerable)
            playerHealth -= healthMod;
        UpdateUI(playerHealth);
    }
    public void UpdateUI(int currentHealth)
    {
        
        for (int i = 0; i < currentHealth; i++)
        {
            missingHearts[i].gameObject.SetActive(false);
        }
        
        if (currentHealth == 4)
            currentHearts[3].gameObject.SetActive(true);
        else
            currentHearts[3].gameObject.SetActive(false);
    }

}
