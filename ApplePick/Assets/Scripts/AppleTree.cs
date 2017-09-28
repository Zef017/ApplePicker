using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleTree : MonoBehaviour {

	// Prefab for instantiatiing Apples
	public GameObject applePrefab;

	//Speed at which the Tree Moves
	public float speed = 1f;

	//Distance Apple Tree Turns around
	public float leftAndRightEdge = 10f;

	//Chance of Changing Directions
	public float chanceToChangeDirection = 0.1f;

	//Rate at which Apples will be instantiantiated
	public float secondsBetweenAppleDrops = 1f;





	// Use this for initialization
	void Start () {
		//Drop Apples Every Second
		InvokeRepeating( "DropApple", 2f, secondsBetweenAppleDrops);
	}

	void DropApple(){
		GameObject apple = Instantiate (applePrefab) as GameObject;
		apple.transform.position = transform.position;

	}
	
	// Update is called once per frame
	void Update () {
		//Basic Movement
		Vector3 pos = transform.position;
		pos.x += speed * Time.deltaTime;
		transform.position = pos;

		//Change Direction
		if (pos.x < -leftAndRightEdge) {
			speed = Mathf.Abs (speed); // Move Right
		} 

		else if (pos.x > leftAndRightEdge) {
			speed = -Mathf.Abs (speed); // Move Left
		} 

	}

	void FixedUpdate(){
		
		if (Random.value < chanceToChangeDirection) {
			speed *= -1; // Change Direction
		}

	}
}
