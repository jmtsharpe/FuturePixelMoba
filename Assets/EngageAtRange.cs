using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EngageAtRange : MonoBehaviour {



	private WaitForSeconds shortWait;
	private Vector2 objectPosition;
	private Vector2 playerSize;
	private GameObject followTarget;
	private GameObject projectile;

	public LayerMask targetLevel;

	public GameObject projectilePrefab;

	public FollowTarget followScript;

	public float AttackDelay;
	public float speed = 5.0f;
	public float EngageRange;
	public float AttackRange;
	public bool attacking;
	public bool engaged;
	public string enemy;


	// Use this for initialization
	void Start() {
		followScript = gameObject.GetComponent<FollowTarget> ();
		shortWait = new WaitForSeconds(AttackDelay);
	}

	public void Restart(){
		followTarget = null;
	}

	public void Shutdown(){
		followTarget = null;
	}

	// Update is called once per frame
	void Update () {
		if (!followTarget && engaged) {
			followTarget = null;
			followScript.RemoveTarget ();
			engaged = false;
		}
		if (!followTarget) {
			var hit = Physics2D.OverlapCircle (transform.position, AttackRange, targetLevel);
			Debug.Log ("Hit = " + hit);
			if (hit) {
				if (hit.transform.gameObject.tag.Contains (enemy) && !attacking) {

					engaged = true;
					followTarget = hit.transform.gameObject;
					followScript.SetTarget (followTarget);
				}
			}
		} else {
			float distance = findDistance (followTarget.transform.position, transform.position);
			if (distance < AttackRange && !attacking) {
				Fire ();
			} else if (distance > EngageRange) {
				followScript.RemoveTarget ();
				followTarget = null;
			}
			
		}
	}

	private float findDistance(Vector3 objPos, Vector3 mousePos){
		float xDist = objPos.x - mousePos.x;
		float yDist = objPos.y - mousePos.y;

		float result = Mathf.Sqrt ((xDist * xDist) + (yDist * yDist));
		return result;
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
}
