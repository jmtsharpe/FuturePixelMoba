using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowTarget : MonoBehaviour {

	public int speed;
	public GameObject target;
	public float stopAt;

	// Use this for initialization
	void Start () {
		target = null;
	}

	public void Restart(){
		target = null;
	}

	public void Shutdown(){
		target = null;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (target) {
			if (target.activeSelf && !InRange()) {
				transform.position = Vector3.MoveTowards (transform.position, target.transform.position, Time.deltaTime * speed);
			}
		}

	}
		
	public void SetTarget(GameObject targ){
		target = targ;
	}

	public void RemoveTarget(){
		target = null;
	}

	public bool InRange(){
		float xDist = target.transform.position.x - transform.position.x;
		float yDist = target.transform.position.y - transform.position.y;

		float result = Mathf.Sqrt ((xDist * xDist) + (yDist * yDist));

		return (result <= stopAt);
	}
}
