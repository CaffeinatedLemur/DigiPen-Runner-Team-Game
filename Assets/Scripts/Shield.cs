using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
    private Animator animator;
    private PlayerHealthHandler playerHealthHandler;
    public AudioClip ac;
    [SerializeField] int duration = 5;
    // Start is called before the first frame update
    void Start()
    {
        playerHealthHandler = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealthHandler>();
        animator = GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            StartCoroutine(ExecuteAfterTime(duration));
            PlayerHealthHandler.isInvulnerable = true;
            animator.SetBool("Shielded", true);
            playerHealthHandler.UpdateUI(PlayerHealthHandler.playerHealth);
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
            collision.GetComponent<AudioSource>().PlayOneShot(ac);
        }
    }
    IEnumerator ExecuteAfterTime(float time)
    {
        yield return new WaitForSeconds(time);
        animator.SetBool("Shielded", false);
        PlayerHealthHandler.isInvulnerable = false;
        playerHealthHandler.UpdateUI(PlayerHealthHandler.playerHealth);
        Destroy(gameObject);
    }

}

