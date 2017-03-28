using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour {

	private float speed = 200f;
	private float movex = 0f;
	private float movey = 0f;
	private Rigidbody2D body2d;

	void Awake(){
		body2d = gameObject.GetComponent<Rigidbody2D> ();
	}

	void Update(){
		if (Input.GetKey (KeyCode.A)){
			Debug.Log ("Left arrow");
			movex = -1f;
		} else if (Input.GetKey (KeyCode.D)) {
			movex = 1f;
		} else {
			movex = 0f;
		}

		if (Input.GetKey (KeyCode.S)) {
			movey = -1f;
		} else if (Input.GetKey (KeyCode.W)) {
			movey = 1f;
		} else {
			movey = 0f;
		}
	}

	// Update is called once per frame
	void FixedUpdate () {

		body2d.velocity = new Vector2 (movex * speed, movey * speed);
	}


}
