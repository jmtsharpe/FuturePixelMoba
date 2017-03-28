using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowTarget : MonoBehaviour {

	public int speed;
	public GameObject target;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (target.activeSelf) {
			
			transform.position = Vector3.MoveTowards (transform.position, target.transform.position, Time.deltaTime * speed);
		} else {
			GameObjectUtil.Destroy (gameObject);
		}
	}

	public void SetTarget(GameObject targ){
		target = targ;
	}
}
