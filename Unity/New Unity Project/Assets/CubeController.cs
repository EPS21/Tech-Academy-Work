﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeController : MonoBehaviour
{
    Vector3 Move;
    float CamWidthX = 6.2f;
    float CamHeightY = 3.4f;
    float Speed = 0.08f;

    float LeftEdge;
    float RightEdge;
    float BottomEdge;
    float TopEdge;

    float Teleport;
    public int CoolCounter;

	// Use this for initialization
	void Start ()
    {
        
        Move = transform.position;

        LeftEdge = CamWidthX * -1;
        RightEdge = CamWidthX;
        BottomEdge = CamHeightY * -1;
        TopEdge = CamHeightY;
	}
	
	// Update is called once per frame
	void Update ()
    {
        // Teleport/Blink
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (CoolCounter == 0)
            {
                Teleport = 2f;
                CoolCounter = 500;
            }
        }
        else
        {
            Teleport = 0;
        }

        CoolCounter--;
        if (CoolCounter < 0)
            CoolCounter = 0;


        // Movement
        if (Input.GetKey(KeyCode.A))
            Move.x -= Speed + Teleport;
        
        if (Input.GetKey(KeyCode.D))
            Move.x += Speed + Teleport;

        if (Input.GetKey(KeyCode.W))
            Move.y += Speed + Teleport;

        if (Input.GetKey(KeyCode.S))
            Move.y -= Speed + Teleport;

        transform.position = Move;
	}

    private void LateUpdate()
    {
        // Check if at the edge of screen and constrain movement if reached
        // Reversed for pac-man like wall properties (move to other side)

        if (transform.position.x < LeftEdge)
            Move.x = RightEdge;
        if (transform.position.x > RightEdge)
            Move.x = LeftEdge;
        if (transform.position.y < BottomEdge)
            Move.y = TopEdge;
        if (transform.position.y > TopEdge)
            Move.y = BottomEdge;

        transform.position = Move;
    }
}
