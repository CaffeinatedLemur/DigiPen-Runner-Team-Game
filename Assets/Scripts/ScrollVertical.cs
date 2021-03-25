//------------------------------------------------------------------------------
//
// File Name:	ScrollHorizontal.cs -> ScrollVertical.cs
// Author(s):	Jeremy Kings (j.kings) - Unity Project
//              Nathan Mueller - original Zero Engine project
//              Mario E -some student

// Project:		Endless Runner
// Course:		WANIC VGP
//
// Copyright © 2021 DigiPen (USA) Corporation.
//
//------------------------------------------------------------------------------

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollVertical : MonoBehaviour
{
    public bool FlipDirection = false;
    public float MoveSpeed = 3.0f;
    public float WrapZoneDown = -18.0f;//left
    public float WrapZoneUp = 56.0f;//right

    // Update is called once per frame
    void Update()
    {
        // Store current position
        Vector3 position = transform.position;

        // Left --> Right, Reset
        if (FlipDirection)
        {
            if (transform.position.y >= WrapZoneUp)
            {
                position.x = WrapZoneDown;
            }
        }
        // Left <-- Right, Reset
        else
        {
            if (transform.position.y <= WrapZoneDown)
            {
                position.y = WrapZoneUp;
            }
        }

        // Move
        if (FlipDirection)
        {
            position.y += MoveSpeed * Time.deltaTime;
        }
        else
        {
            position.y -= MoveSpeed * Time.deltaTime;
        }

        // Set new position
        transform.position = position;
    }
}
