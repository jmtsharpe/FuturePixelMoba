using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorizontalMove : MonoBehaviour {

	private float speed = 69;
	private float upSpeed;
	private Rigidbody2D body2d;

	void Awake(){
		body2d = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey (KeyCode.LeftArrow)) {
			upSpeed = body2d.velocity.y;
			body2d.velocity = new Vector2 (-(speed), upSpeed);
		} else if (Input.GetKey (KeyCode.RightArrow)) {
			upSpeed = body2d.velocity.y;
			body2d.velocity = new Vector2 (speed, upSpeed);
		} else {
			upSpeed = body2d.velocity.y;
			body2d.velocity = new Vector2 (0, upSpeed);
		}
	}
}
