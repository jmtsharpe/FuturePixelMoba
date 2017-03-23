using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationManager : MonoBehaviour {

	private Animator animator;
	private InputState inputState;
	private Shoot shoot;

	void Awake(){
		animator = GetComponent<Animator> ();
		inputState = GetComponent<InputState> ();
		shoot = GetComponent<Shoot> ();
	}
	
	// Update is called once per frame
	void FixedUpdate () {

		var running = true;
		var shooting = false;
		var jumping = false;


		if (inputState.velX < 0 && inputState.absVelY < inputState.standingThreshold) {
			running = false;
		}

		if (shoot.shooting) {
			shooting = true;
		}

		if(inputState.absVelY > 1){
			jumping = true;
		}






		animator.SetBool ("Jumping", jumping);
		animator.SetBool ("Running", running);
		animator.SetBool ("Shooting", shooting);

	}
}
