
//------------------------------------------------------------------------------
//
// File Name:	PlayerMovementController.cs
// Author(s):	Jeremy Kings (j.kings) - Unity Project
//              Nathan Mueller - original Zero Engine project
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
    public float MoveSpeed = 10;
    public int MaxHealth = 3;
    public float JumpHeight = 5;
    public int MaxNumberOfJumps = 2;
    public KeyCode JumpKey = KeyCode.Space;
    public KeyCode SlideKey = KeyCode.LeftShift;
    public KeyCode RightKey = KeyCode.RightArrow;
    public KeyCode LeftKey = KeyCode.LeftArrow;
    public AudioClip Ac;
    public bool chainJumping;
    public Animator playerAnimator;
    public Animator dinoboiAnimator;

    private int jumpsRemaining = 0;
    private string nameOfHealthDisplayObject = "HealthBar";
    private string nameOfDistanceLabelObject = "DistanceLabel";
    private GameObject healthBarObj = null;
    private Rigidbody2D myRB;
    private SpriteRenderer spriteRenderer;
    private AudioSource As;
    
    // Start is called before the first frame update
    void Start()
    {
        As = GetComponent<AudioSource>();
        healthBarObj = GameObject.Find(nameOfHealthDisplayObject);
        myRB = GetComponent<Rigidbody2D>();
        if (healthBarObj != null)
        {
            healthBarObj.GetComponent<FeedbackBar>().SetMax(MaxHealth);
        }

        // Take the square root of the jump height so that the math for gravity works
        // to make the number the user enters the number of units the player will
        // actually be able to jump
        JumpHeight = Mathf.Sqrt(2.0f * Physics2D.gravity.magnitude * JumpHeight);
        spriteRenderer = GetComponent<SpriteRenderer>();

        // Reset score
        PlayerSaveData.DistanceRun = 0;
    }

    // Update is called once per frame
    void Update()
    {
        bool grounded = IsGrounded();
        
        if (jumpsRemaining > 0)
        {
            As.PlayOneShot(Ac);
            playerAnimator.SetBool("Scronch", false);
            dinoboiAnimator.SetBool("Scronch", false);

            var jump_vec = new Vector3(myRB.velocity.x, JumpHeight, 0);
            gameObject.GetComponent<Rigidbody2D>().velocity = jump_vec;
            jumpsRemaining -= 1;
        }
        
        if (Input.GetKeyDown(RightKey)) {
            var Right_vec = new Vector2(7, myRB.velocity.y);
            myRB.velocity = Right_vec;
        }
        if (Input.GetKeyDown(LeftKey))
        {
            var Left_vec = new Vector2(-7, myRB.velocity.y);
            myRB.velocity = Left_vec;
        }
        if (myRB.velocity.x > 0.01f) 
        {
            spriteRenderer.flipX = false;
        }
        if (myRB.velocity.x < -0.01f)
        {
            spriteRenderer.flipX = true;
        }


        if (myRB.velocity.y < 0)
        {
            myRB.velocity += Vector2.up * Physics2D.gravity.y * (1.1f - 1) * Time.deltaTime;
            playerAnimator.SetBool("InAir", true);
            dinoboiAnimator.SetBool("InAir", true);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.collider.gameObject.CompareTag("Floor"))
        {
            if (chainJumping)
            {
                ResetAnim();
                StartCoroutine(ResetJumps(0.3f));
            }
            else
            {
                if (myRB.velocity.y == 0)
                {
                    ResetAnim();
                    StartCoroutine(ResetJumps(0.3f));
                }
            }
        }
        
    }


    IEnumerator ResetJumps(float time)
    {

        yield return new WaitForSeconds(time);
        jumpsRemaining = MaxNumberOfJumps;

    }

    private void ResetAnim()
    {
        playerAnimator.SetBool("InAir", false);
        playerAnimator.SetBool("Scronch", true);

        dinoboiAnimator.SetBool("InAir", false);
        dinoboiAnimator.SetBool("Scronch", true);
    }

    public bool IsGrounded()
    {
       
        return jumpsRemaining == MaxNumberOfJumps;

    }
}
