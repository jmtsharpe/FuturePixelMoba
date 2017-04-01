using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoToObjective : MonoBehaviour {
	public bool engaged;
	public EngageAtRange engageScript;
	private Vector3 toLine;
	public float speed;

	// Use this for initialization
	void Start () {
		engageScript = gameObject.GetComponent<EngageAtRange> ();
	}
	
	// Update is called once per frame
	void Update () {
		engaged = engageScript.engaged;
		if (gameObject.CompareTag ("Zombie") && !engaged) {
			Vector3 toLine = ObjectiveLineLeft ();
			transform.position = Vector3.MoveTowards (transform.position, toLine, Time.deltaTime * speed);
		}
	}

	private Vector3 ObjectiveLineLeft(){
		return new Vector3 (transform.position.x - 20, 0, transform.position.z);
	}

	private Vector3 ObjectiveLineRight(){
		return new Vector3 (transform.position.x + 20, 0, transform.position.z);
	}
}
