using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseToMove : MonoBehaviour {

	public int speed;
	public Vector3 targetPosition;

	// Update is called once per frame
	void Update () {

		if (Input.GetMouseButton (0)) {
			targetPosition = Camera.main.ScreenToWorldPoint (Input.mousePosition);
			targetPosition.z = transform.position.z;
			transform.position = Vector3.MoveTowards (transform.position, targetPosition, Time.deltaTime * speed);
		} else if (Input.GetMouseButton (1)) {
			targetPosition = transform.position;
		} else {
			transform.position = Vector3.MoveTowards(transform.position, targetPosition, Time.deltaTime * speed);
		}


	}

}


