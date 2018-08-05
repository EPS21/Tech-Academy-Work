using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereController : MonoBehaviour
{
    GameObject CubeReference;
    Vector3 CubeRefPosition;
    float Speed = 0.01f;
    public Vector2 Distance;

    public int Timer;
    Vector3 RandomSpawn;

	// Use this for initialization
	void Start ()
    {
        // Reference to our Cube/Player1 GameObject
        CubeReference = GameObject.Find("Cube1");
        Timer = 1;
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
        
        // Spawn duplicate enemies every 500 tick
        if(Timer % 250 == 0)
        {
            RandomSpawn.x = Random.Range(-6.2f, 6.2f);
            RandomSpawn.y = Random.Range(-3.4f, 3.4f);
            RandomSpawn.z = transform.position.z;
            GameObject.Instantiate(this.gameObject, RandomSpawn, transform.rotation); // this.gameObject 'this' is for making another sphere object (and not something else)
        }
        Timer++;
              

	}
}
