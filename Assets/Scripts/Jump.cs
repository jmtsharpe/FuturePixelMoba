﻿using UnityEngine;
using System.Collections;

public class Jump : MonoBehaviour {

	public float jumpSpeed = 240f;

	private Rigidbody2D body2d;
	private InputState inputState;

	void Awake(){
		body2d = GetComponent<Rigidbody2D> ();
		inputState = GetComponent<InputState> ();
	}

	// Update is called once per frame
	void Update () {

		if (inputState.standing) {
			if(Input.GetKeyDown("up")){
				body2d.velocity = new Vector2(0, jumpSpeed);
			}
		}

	}
}
