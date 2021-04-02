/*******************************************
 * Authors: Mario E, with minor additions made by Thomas A
 * Date: 4/2/2021
 * Desc: Handles actions when the player picks up a jetpack powerup
 * ****************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JetPack : MonoBehaviour
{
    private SpriteRenderer sp; //prite renderer of gameobject
    private Rigidbody2D playerRB; //rigidbody of player
    private bool enabled; //wether or not it's on
    private float timer; //a timer to handle duration
    public float timespan; //max timespan/duration
    public AudioClip ac; //audioclip to play on pickup

    private Animator animator; //animator of player
    // Start is called before the first frame update
    void Start()
    {
        //find the spriterenderer
        sp = GetComponent<SpriteRenderer>();
        //find the animator of the player
        animator = GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //if it's on
        if (enabled)
        {
            //move the player up
            playerRB.velocity = Vector3.up * 15;
            //update animator
            animator.SetBool("Flying", true);
            //update timer
            timer += Time.deltaTime;
            //if the timer has lasted its duration, 
            if (timer >= timespan)
            {
                //turn of the animation
                animator.SetBool("Flying", false);
                //turn off the powerup
                enabled = false;
                //reset the timer
                timer = 0;
                //and kill it
                Destroy(gameObject);//object is kil
            }
        }
        //otherwise make sure the flight animation is not playing
        else
        {
            animator.SetBool("Flying", false);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)//when it hits the player it turns invisible and such
    {
        //make sure its the player
        if (collision.CompareTag("Player"))
        {
            //child to player to prevent deletion
            gameObject.transform.parent = collision.gameObject.transform;
            //get the player's rb so that you can add force
            playerRB = collision.GetComponent<Rigidbody2D>();
            //make it invisisble
            sp.color = new Color(1f, 1f, 1f, 0f);
            //turn it on
            enabled = true;
            //reset player velocity
            playerRB.velocity = Vector3.zero;
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
            //play the sound
            collision.GetComponent<AudioSource>().PlayOneShot(ac);
        }
    }
}
