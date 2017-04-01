using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour {

	public GameObject bulletPrefab;

	private Camera screen;

	private WaitForSeconds shortWait;
	private Vector2 playerPosition;
	private Vector2 playerSize;
	private GameObject bullet;
	public bool shooting;
	private GameObject followTarget;

	public float attackRange;
	public float attackDelay;

	void Awake() {
		playerSize = GetComponent<BoxCollider2D> ().size;
	
	}

	void Start(){
		screen = Camera.main;
		shortWait = new WaitForSeconds(attackDelay);
	}



	public void Fire() {
		shooting = true;
		playerPosition = GetComponent<Transform> ().position;
		Vector2 target = screen.ScreenToWorldPoint( new Vector2(Input.mousePosition.x, Input.mousePosition.y) );
		Vector2 myPos = new Vector2(playerPosition.x + (playerSize.x /2) + 5 , playerPosition.y);
		Vector2 direction = target - myPos;

		bullet = GameObjectUtil.Instantiate(bulletPrefab, new Vector3(playerPosition.x + (playerSize.x /2) + 5 , playerPosition.y, 0));
		bullet.GetComponent<MissileSeekTarget>().SetTarget (followTarget);
		StopCoroutine ("AttackPause");
		StartCoroutine ("AttackPause");

	}

	IEnumerator AttackPause(){
		yield return shortWait;
		shooting = false;
	}


	// Update is called once per frame
	void Update () {
		
		if (Input.GetMouseButtonDown(1) && !shooting)
		{
			
			float distance = findDistance (gameObject.transform.position, Camera.main.ScreenToWorldPoint (Input.mousePosition));
			if(distance < attackRange){
				var ray = Camera.main.ScreenPointToRay (Input.mousePosition);
				var hit = Physics2D.Raycast(ray.origin, ray.direction * attackRange);
				if (hit) 
				{
					var hitTarget = hit.transform.gameObject.tag;
					if (hitTarget.Contains("Red"))
					{
						followTarget = hit.transform.gameObject;
						Fire ();
					}
				}
			}

		} 
	}

	private float findDistance(Vector3 objPos, Vector3 mousePos){
		float xDist = objPos.x - mousePos.x;
		float yDist = objPos.y - mousePos.y;

		float result = Mathf.Sqrt ((xDist * xDist) + (yDist * yDist));
		return result;
	}
}


