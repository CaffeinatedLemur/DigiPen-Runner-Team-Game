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
        tf = true;
    }
}
