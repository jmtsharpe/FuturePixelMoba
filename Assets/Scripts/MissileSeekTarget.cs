using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileSeekTarget : MonoBehaviour {

	public int speed;
	public GameObject target;

	void FixedUpdate () {
		if (target && target.activeSelf) {
			transform.position = Vector3.MoveTowards (transform.position, target.transform.position, Time.deltaTime * speed);
		} else {
			GameObjectUtil.Destroy (gameObject);
		}

	}
		
	public void SetTarget(GameObject targ){
		target = targ;
	}

	public void RemoveTarget(){
		target = null;
	}
}
