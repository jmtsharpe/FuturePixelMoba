using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerAttack : MonoBehaviour {

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
			if (!followTarget.activeSelf || !InRange()) {
				followTarget = null;
			} else if (!attacking) {
				Fire ();
			}
		} else {
			var hit = Physics2D.OverlapCircle (transform.position, AttackRange, -1);
			if (hit && !(attacking)) {
				if (hit.gameObject.tag.Contains (enemy)) {
					followTarget = hit.gameObject;
					Fire ();
				}
			}
		}
	}

	public bool InRange(){
		float xDist = followTarget.transform.position.x - transform.position.x;
		float yDist = followTarget.transform.position.y - transform.position.y;

		float result = Mathf.Sqrt ((xDist * xDist) + (yDist * yDist));

		return (result <= AttackRange);
	}

}
