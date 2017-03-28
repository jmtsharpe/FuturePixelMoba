using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour {

	public GameObject bulletPrefab;

	private Camera screen;
	private WaitForSeconds shortWait = new WaitForSeconds(0.25f);
	private Vector2 playerPosition;
	private Vector2 playerSize;
	private GameObject bullet;
	public bool shooting;
	private GameObject followTarget;

	public float attackRange;

	void Awake() {
		playerSize = GetComponent<BoxCollider2D> ().size;
	
	}

	void Start(){
		screen = Camera.main;
	}

	public void Fire(){
		playerPosition = GetComponent<Transform> ().position;
		StopCoroutine("FireRoutine");
		StartCoroutine("FireRoutine");
	}

	IEnumerator FireRoutine() {
		playerPosition = GetComponent<Transform> ().position;
		Vector2 target = screen.ScreenToWorldPoint( new Vector2(Input.mousePosition.x, Input.mousePosition.y) );
		Vector2 myPos = new Vector2(playerPosition.x + (playerSize.x /2) + 5 , playerPosition.y);
		Vector2 direction = target - myPos;

		bullet = GameObjectUtil.Instantiate(bulletPrefab, new Vector3(playerPosition.x + (playerSize.x /2) + 5 , playerPosition.y, 0));
		bullet.GetComponent<FollowTarget>().SetTarget (followTarget);
		shooting = true;
		yield return shortWait;
		shooting = false;
	}

	// Update is called once per frame
	void Update () {
		
		if (Input.GetMouseButtonDown(1))
		{
			
			float distance = findDistance (gameObject.transform.position, Camera.main.ScreenToWorldPoint (Input.mousePosition));
			if(distance < attackRange){
			Debug.Log("Mouse is down");
			var ray = Camera.main.ScreenPointToRay (Input.mousePosition);
			var hit = Physics2D.Raycast(ray.origin, ray.direction * attackRange);
			if (hit) 
			{
				var hitTarget = hit.transform.gameObject.tag;
				if (hitTarget == "Zombie" || hitTarget == "Tower")
				{
					followTarget = hit.transform.gameObject;
					Fire ();
					Debug.Log ("It's working!");
				} else {
					Debug.Log ("nopz");
				}
			} else {
				Debug.Log("No hit");
			}
			Debug.Log("Mouse is down");
			}

		} 
	}

	private float findDistance(Vector3 objPos, Vector3 mousePos){
		float xDist = objPos.x - mousePos.x;
		float yDist = objPos.y - mousePos.y;

		float result = Mathf.Sqrt ((xDist * xDist) + (yDist * yDist));
		Debug.Log (result);
		return result;
	}
}


