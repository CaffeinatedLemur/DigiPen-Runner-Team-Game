﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JetPack : MonoBehaviour
{
    private SpriteRenderer sp;
    private Rigidbody2D playerRB ;
    private bool enabled;
    private float timer;
    public float timespan;
    // Start is called before the first frame update
    void Start()
    {
        sp = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (enabled)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                playerRB.AddForce(new Vector2(0, 5));//while it's held down it pushes the player up
            }
            timer++;
            if (timer >= timespan)
            {
                enabled = false;
                timer = 0;
                Destroy(sp.gameObject);//object is kil
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)//when it hits the player it turns invisible and such
    {
        if (collision.CompareTag("Player")) { 
        playerRB = collision.GetComponent<Rigidbody2D>();
        sp.color = new Color(1f, 1f, 1f, 0f);
        enabled = true;
        }
    }
}
