/*******************************************
 * Authors: Thomas A. Sounds implemented by Mario E
 * Date: 4/2/2021
 * Desc: Put this on an object to cause the player to be invulnerable for a given duration
 * ****************************************/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
    private Animator animator; //player's animator
    private PlayerHealthHandler playerHealthHandler; //health scripts
    public AudioClip ac; //audio sclip to play
    [SerializeField] int duration = 5; //duration of the shield
    // Start is called before the first frame update
    void Start()
    {
        playerHealthHandler = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealthHandler>(); //get the script
        animator = GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>(); //get the animator
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            //child it to the player so that it wont get deleted
            gameObject.transform.parent = collision.gameObject.transform;
            //start the countdown
            StartCoroutine(ExecuteAfterTime(duration));
            //make the player invulnerable
            PlayerHealthHandler.isInvulnerable = true;
            //turn on the animation
            animator.SetBool("Shielded", true);
            //update the UI so that it will include the shield hearts to signify invulnerability
            playerHealthHandler.UpdateUI(PlayerHealthHandler.playerHealth);
            //make the object invisible
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
            //play the powerup sound
            collision.GetComponent<AudioSource>().PlayOneShot(ac);
        }
    }

    IEnumerator ExecuteAfterTime(float time)
    {
        //wait until duration is up
        yield return new WaitForSeconds(time);
        //update the animator
        animator.SetBool("Shielded", false);
        //disable invulnerability
        PlayerHealthHandler.isInvulnerable = false;
        //update the UI to remove the shields over the hearts
        playerHealthHandler.UpdateUI(PlayerHealthHandler.playerHealth);
        //delete the powerup
        Destroy(gameObject);
    }

}

