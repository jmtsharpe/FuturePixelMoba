using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackInRange : MonoBehaviour {

	public GameObject projectilePrefab;

	private Camera screen;
	private WaitForSeconds shortWait;
	private Vector2 objectPosition;
	private Vector2 playerSize;
	public float speed = 5.0f;
	private GameObject projectile;
	public bool shooting;
	private GameObject followTarget;

	public float AttackDelay;
	public float AttackRange;

	// Use this for initialization
	void Start () {
		shortWait = new WaitForSeconds(AttackDelay);
	}

	public void Fire(){
		objectPosition = GetComponent<Transform> ().position;
		StopCoroutine("FireRoutine");
		StartCoroutine("FireRoutine");
	}

	IEnumerator FireRoutine() {
		objectPosition = GetComponent<Transform> ().position;
		Vector2 myPos = new Vector2(objectPosition.x + (objectPosition.x /2) + 5 , objectPosition.y);

		projectile = GameObjectUtil.Instantiate(projectilePrefab, new Vector3(objectPosition.x + (playerSize.x /2) + 5 , objectPosition.y, 0));
		projectile.GetComponent<FollowTarget>().SetTarget (followTarget);
		shooting = true;
		yield return shortWait;
		shooting = false;
	}
	
	// Update is called once per frame
	void Update () {
		var hit = Physics2D.OverlapCircle(transform.position, AttackRange);
		if (hit && !(shooting)) 
		{
			if (hit.transform.gameObject.tag == "Player")
			{
				followTarget = hit.transform.gameObject;
				Fire ();
			}
		}
	}
}
