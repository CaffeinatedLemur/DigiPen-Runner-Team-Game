/*******************************************
 * Authors: Mario E, ended up not being used
 * Date: 4/2/2021
 * Desc: Handles the moving platform
 * ****************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    private Transform myTr;
    private bool moveR = true;
    public float moveWidth = 4;
    public float moveSpeed = 0.1f;
    private float originX;
    // Start is called before the first frame update
    void Start()
    {
        myTr = GetComponent<Transform>();
        originX = myTr.position.x;//stores original position
    }

    // Update is called once per frame
    void Update()
    {
        if (moveR)//don't remove this, else it doesn't start
        {
            myTr.position = new Vector3(myTr.position.x + moveSpeed, myTr.position.y, myTr.position.z);//moves right
            if (myTr.position.x > originX +(moveWidth / 2)) moveR = false;//if it goes past half the width it changes
        }
        else 
        {
            myTr.position = new Vector3(myTr.position.x - moveSpeed, myTr.position.y, myTr.position.z);//moves left
            if (myTr.position.x < originX - (moveWidth / 2)) moveR = true;
        }
    }
}
