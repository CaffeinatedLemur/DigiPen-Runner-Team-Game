/*******************************************
 * Authors: Thomas A
 * Date: 4/2/2021
 * Desc: Deletes old old stuff when player moves away from it and a cooldown has ended. Works mostly as a failsafe.
 * ****************************************/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DestroyAfterTime : MonoBehaviour
{

    [SerializeField] float timLimit = 10; //how long before it gets deleted
    public Transform playerTransform; //the player
    private float temp = 0; //timer that counts up
    // Start is called before the first frame update
    void Start()
    {
        //find the player
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        //update timer
        temp += Time.deltaTime;
        //make sure the object still exists
        try
        {
            //destroy it if the player is nolonger around it and the coundown is up
            if (temp >= timLimit && playerTransform.transform.position.y > gameObject.transform.position.y + 20)
                Destroy(gameObject);
        }
        //if it doesnt, we have bigger problems. Load death scene?
        catch
        {
            //dont remeber why I added this here but it is probably important?
            SceneManager.LoadScene(2);
        }
    }
}
