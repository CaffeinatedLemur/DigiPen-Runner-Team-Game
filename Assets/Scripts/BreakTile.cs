/*Name: BreakTile.cs
 *Date: 3/26/2021
 *Desc: allows for tile to be dropped after set amount of time from collision
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakTile : MonoBehaviour
{
    private float timer;
    private bool tf = false;
    public float holdTil = 1;
    public float DestroyAt = 3;
    private Rigidbody2D myRB;
    private BoxCollider2D myCollider;
    public AudioClip ac;
    // Start is called before the first frame update
    void Start()
    { 
        myCollider = GetComponent<BoxCollider2D>();
        myRB=GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (tf) {//starts timer
            timer += Time.deltaTime;
            if (timer > holdTil) {
                myRB.constraints = RigidbodyConstraints2D.FreezePositionX;
                if (timer > DestroyAt)
                {
                    Destroy(myRB.gameObject);//despawns
                }
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D col)
    {
        col.gameObject.GetComponent<AudioSource>().PlayOneShot(ac);
        tf = true;
    }
}
