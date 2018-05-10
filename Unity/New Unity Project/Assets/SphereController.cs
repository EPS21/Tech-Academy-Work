using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereController : MonoBehaviour
{
    GameObject CubeReference;
    Vector3 CubeRefPosition;
    float Speed = 0.09f;
    public Vector2 Distance;

	// Use this for initialization
	void Start ()
    {
        // Reference to our Cube/Player1 GameObject
        CubeReference = GameObject.Find("Cube1");		
	}
	
	// Update is called once per frame
	void Update ()
    {
        // Sphere tracks position of player1 and follows
        CubeRefPosition = CubeReference.transform.position;
        transform.position = Vector3.MoveTowards(transform.position, CubeRefPosition, Speed);

        // Check Distance between player1 & enemy
        Distance.x = transform.position.x - CubeRefPosition.x;
        Distance.y = transform.position.y - CubeRefPosition.y;

        // If occupying same space as you, you've been eaten
        
        if (((Distance.x < 0.1f) && (Distance.x > -0.1f)) &&
            ((Distance.y < 0.1f) && (Distance.y > -0.1f))) 
        {
            GameObject.Destroy(CubeReference);
            Debug.Log("You have been eaten!");
        }
        
              

	}
}
