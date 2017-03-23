using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : MonoBehaviour {

	public Vector2 colliderOffset = Vector2.zero;


	// Use this for initialization
	void Start () {
		
	}
	
	public void Restart(){
		var renderer = GetComponent<SpriteRenderer> ();

		var collider = GetComponent<BoxCollider2D> ();
		var size = renderer.bounds.size;
		size.y += colliderOffset.y;

		collider.size = size;
		collider.offset = new Vector2 (-colliderOffset.x, collider.size.y / 2 + colliderOffset.y);

	}

	public void Shutdown(){

	}
}
