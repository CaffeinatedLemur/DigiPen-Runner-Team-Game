
//------------------------------------------------------------------------------
//
// File Name:	PlayerMovementController.cs
// Author(s):	Jeremy Kings (j.kings) - Unity Project
//              Nathan Mueller - original Zero Engine project
//              Thomas A - Student 
//              Mario E - Student
// Project:		Endless Runner
// Course:		WANIC VGP
//
// Copyright © 2021 DigiPen (USA) Corporation.
//
//------------------------------------------------------------------------------

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class movement : MonoBehaviour
{
    public float JumpHeight = 5; //how high player jumps
    public int MaxNumberOfJumps = 2; //max number of jumps b4 reset
    //controls options
    public KeyCode JumpKey = KeyCode.Space;
    public KeyCode SlideKey = KeyCode.LeftShift;
    public KeyCode RightKey = KeyCode.RightArrow;
    public KeyCode LeftKey = KeyCode.LeftArrow;
    public AudioClip Ac; //audioclip to player on jump
    public AudioClip AAc; //landing sound
    public bool chainJumping; //wether or not to allow for chainjumping between platforms
    public Animator playerAnimator; //animator of player
    public Animator dinoboiAnimator; //animator of the dino

    private int jumpsRemaining = 0; //how many jumps you have

    private Rigidbody2D myRB; //rb of player
    private SpriteRenderer spriteRenderer; //priterenderer of player
    private AudioSource As; //ausiosource of player

    // Start is called before the first frame update
    void Start()
    {
        //get componenets from the player
        As = GetComponent<AudioSource>(); 
        myRB = GetComponent<Rigidbody2D>();


        // Take the square root of the jump height so that the math for gravity works
        // to make the number the user enters the number of units the player will
        // actually be able to jump
        JumpHeight = Mathf.Sqrt(2.0f * Physics2D.gravity.magnitude * JumpHeight);
        spriteRenderer = GetComponent<SpriteRenderer>();

        // Reset score
   }

    // Update is called once per frame
    void Update()
    {
        //check if they are grounded
        bool grounded = IsGrounded();
        //make sure the player isnt going to infinatly jump
        if (jumpsRemaining > 0)
        {
            //play the jump sound
            As.PlayOneShot(Ac);
            //update the animations
            playerAnimator.SetBool("Scronch", false);
            dinoboiAnimator.SetBool("Scronch", false);
            //update vector3
            var jump_vec = new Vector3(myRB.velocity.x, JumpHeight, 0);
            //add velocity
            gameObject.GetComponent<Rigidbody2D>().velocity = jump_vec;
            //subtract a jump
            jumpsRemaining -= 1;
        }
        //move right
        if (Input.GetKeyDown(RightKey)) {
            var Right_vec = new Vector2(7, myRB.velocity.y);
            myRB.velocity = Right_vec;
        }
        //move left
        if (Input.GetKeyDown(LeftKey))
        {
            var Left_vec = new Vector2(-7, myRB.velocity.y);
            myRB.velocity = Left_vec;
        }
        //flip the player around
        if (myRB.velocity.x > 0.01f) 
        {
            spriteRenderer.flipX = false;
        }
        if (myRB.velocity.x < -0.01f)
        {
            spriteRenderer.flipX = true;
        }
        //make player fall down faster for a less floaty jump
        if (myRB.velocity.y < 0)
        {
            myRB.velocity += Vector2.up * Physics2D.gravity.y * (1.1f - 1) * Time.deltaTime;
            playerAnimator.SetBool("InAir", true);
            dinoboiAnimator.SetBool("InAir", true);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //if you hit the floor,
        if (collision.collider.gameObject.CompareTag("Floor"))
        {
            //reset jump immediatly and allow the player to continue going up if you want the player to chainjump
            if (chainJumping)
            {
                ResetAnim();
                StartCoroutine(ResetJumps(0.3f));
            }
            else
            {
                //otherwise only reset jumps once playre is still and landed
                if (myRB.velocity.y == 0)
                {
                    As.PlayOneShot(AAc);
                    ResetAnim();
                    StartCoroutine(ResetJumps(0.3f));
                }
            }
        }
        
    }


    IEnumerator ResetJumps(float time)
    {
        //reset jumps after scronch animation plays
        yield return new WaitForSeconds(time);
        jumpsRemaining = MaxNumberOfJumps;

    }

    private void ResetAnim()
    {
        //turn off all bool, turn on scronch
        playerAnimator.SetBool("InAir", false);
        playerAnimator.SetBool("Scronch", true);

        dinoboiAnimator.SetBool("InAir", false);
        dinoboiAnimator.SetBool("Scronch", true);
    }

    public bool IsGrounded()
    {
       //getter function to update bool
       return jumpsRemaining == MaxNumberOfJumps;
    }
}
