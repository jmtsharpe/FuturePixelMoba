using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackInRange : MonoBehaviour {

	private Camera screen;
	private WaitForSeconds shortWait;
	private Vector2 objectPosition;
	private Vector2 objectSize;
	private GameObject projectile;
	public GameObject followTarget;

	public GameObject projectilePrefab;
	public bool attacking;
	public float AttackDelay;
	public float AttackRange;
	public string enemy;

	void Start () {
		shortWait = new WaitForSeconds(AttackDelay);
	}
		

	public void Fire(){
		attacking = true;
		objectPosition = GetComponent<Transform> ().position;
		StopCoroutine("FireRoutine");
		StartCoroutine("FireRoutine");
	}

	IEnumerator FireRoutine() {
		gameObject.GetComponent<Rigidbody2D> ().velocity = new Vector2(0, 0);
		objectPosition = GetComponent<Transform> ().position;
		Vector2 myPos = new Vector2(objectPosition.x + (objectPosition.x /2) + 5 , objectPosition.y);

		projectile = GameObjectUtil.Instantiate(projectilePrefab, new Vector3(objectPosition.x, objectPosition.y, 0));
		projectile.GetComponent<MissileSeekTarget>().SetTarget (followTarget);
		yield return shortWait;
		attacking = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (followTarget) {
			if (!followTarget.activeSelf) {
				followTarget = null;
			} else if (!attacking) {
				Fire ();
			}
		} else {
			Debug.Log (gameObject + " hit nothing yet");
			var hit = Physics2D.OverlapCircle (transform.position, AttackRange, 0, 0, -2);
			if (hit && !(attacking)) {
				Debug.Log (gameObject + " hit " + hit);
				if (hit.gameObject.tag.Contains (enemy)) {
					followTarget = hit.gameObject;
					Fire ();
				}
			}
		}
	}

}
