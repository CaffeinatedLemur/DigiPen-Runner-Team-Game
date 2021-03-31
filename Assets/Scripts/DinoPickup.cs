using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DinoPickup : MonoBehaviour
{
    //[SerializeField] GameObject dinoBoiPlayer;

    private PlayerHealthHandler playerHealthHandler;
    private void Start()
    {
        //dinoBoiPlayer = FindObjectOfType<DinoFollower>().gameObject;
        playerHealthHandler = FindObjectOfType<PlayerHealthHandler>();
        if (FindObjectsOfType<DinoPickup>().Length > 2)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerHealthHandler.AddDino(true);
        }
        Destroy(gameObject);
    }
}
