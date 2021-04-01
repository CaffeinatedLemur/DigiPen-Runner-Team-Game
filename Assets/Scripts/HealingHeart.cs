using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealingHeart : MonoBehaviour
{
    private PlayerHealthHandler playerHealthHandler;
    public AudioClip ac;
    // Start is called before the first frame update
    void Start()
    {
        playerHealthHandler = FindObjectOfType<PlayerHealthHandler>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerHealthHandler.AddHealth(1);
            Destroy(gameObject);
            collision.GetComponent<AudioSource>().PlayOneShot(ac);
        }
        
    }
}
