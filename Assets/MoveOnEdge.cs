using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveOnEdge : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	void Update() {
		Vector2 mouseEdge = MouseScreenEdge( 20 );
		if( !( Mathf.Approximately( mouseEdge.x, 0f) ) ) {
			//Move your camera depending on the sign of mouse.Edge.x
			if( mouseEdge.x < 0 ) {
				Vector3 temp = new Vector3 (-2, 0, 0);
				gameObject.transform.position += temp;
			}
			else {
				Vector3 temp = new Vector3 (2, 0, 0);
				gameObject.transform.position += temp;
			}
		}
	}

	Vector2 MouseScreenEdge( int margin ) {
		//Margin is calculated in px from the edge of the screen

		Vector2 half = new Vector2( Screen.width/2, Screen.height/2 );

		//If mouse is dead center, (x,y) would be (0,0)
		float x = Input.mousePosition.x - half.x;
		float y = Input.mousePosition.y - half.y;   

		//If x is not within the edge margin, then x is 0;
		//In another word, not close to the edge
		if( Mathf.Abs(x) > half.x-margin ) {
			if (x < 0) {
				x += (half.x-margin) * 1;
			} else {
				x += (half.x-margin) * -1;
			}
		}
		else {
			x = 0f;
		}

		if( Mathf.Abs(y) > half.y-margin ) {
			if (y < 0) {
				y += (half.y-margin) * 1;
			} else {
				y += (half.y-margin) * -1;
			}
		}
		else {
			y = 0f;
		}

		return new Vector2( x, y );
	}
}
