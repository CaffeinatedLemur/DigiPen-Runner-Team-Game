using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    public GameObject OtherPortal;
    public float cooldownLimit = 600;

    public bool cooldown = false;
    private Collider2D myCol;
    private float timer = 0;
    public AudioClip ac;
    // Start is called before the first frame update
    void Start()
    {
        myCol = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (cooldown)
        {
            timer++;
            if (timer >= cooldownLimit)
            {
                cooldown = false;
                timer = 0;
            }
        }
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (OtherPortal != null && !cooldown)
        {
            OtherPortal.GetComponent<Portal>().cooldown = true;
            collision.gameObject.transform.position = OtherPortal.transform.position;
            cooldown = true;
            collision.GetComponent<AudioSource>().PlayOneShot(ac);
        }
    }
}
