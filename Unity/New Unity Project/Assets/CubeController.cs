using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeController : MonoBehaviour
{
    Vector3 Move;
    float CamWidthX = 6.2f;
    float CamHeightY = 3.4f;


	// Use this for initialization
	void Start ()
    {
        Move = transform.position;
	}
	
	// Update is called once per frame
	void Update ()
    {
        // Movement
        if (Input.GetKey(KeyCode.A))
            Move.x -= 0.09f;

        if (Input.GetKey(KeyCode.D))
            Move.x += 0.09f;

        if (Input.GetKey(KeyCode.W))
            Move.y += 0.09f;

        if (Input.GetKey(KeyCode.S))
            Move.y -= 0.09f;

        transform.position = Move;
	}

    private void LateUpdate()
    {
        // Check if at the edge of screen and constrain movement if reached

        if (transform.position.x < CamWidthX * -1)
            Move.x = CamWidthX * -1;
        if (transform.position.x > CamWidthX * 1)
            Move.x = CamWidthX * 1;
        if (transform.position.y < CamHeightY * -1)
            Move.y = CamHeightY * -1;
        if (transform.position.y > CamHeightY * 1)
            Move.y = CamHeightY * 1;

        transform.position = Move;
    }
}
