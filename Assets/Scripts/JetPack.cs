using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JetPack : MonoBehaviour
{
    private SpriteRenderer sp;
    private Rigidbody2D playerRB;
    private bool enabled;
    private float timer;
    public float timespan;
    public AudioClip ac;

    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        sp = GetComponent<SpriteRenderer>();
        animator = GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (enabled)
        {
            playerRB.AddForce(new Vector2(0, 5));
            animator.SetBool("Flying", true);
            timer += Time.deltaTime;
            if (timer >= timespan)
            {
                animator.SetBool("Flying", false);

                enabled = false;
                timer = 0;

                Destroy(gameObject);//object is kil
            }
        }
        else
        {
            animator.SetBool("Flying", false);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)//when it hits the player it turns invisible and such
    {
        if (collision.CompareTag("Player"))
        {
            gameObject.transform.parent = collision.gameObject.transform;
            playerRB = collision.GetComponent<Rigidbody2D>();
            sp.color = new Color(1f, 1f, 1f, 0f);
            enabled = true;
            collision.GetComponent<AudioSource>().PlayOneShot(ac);
        }
    }
}
