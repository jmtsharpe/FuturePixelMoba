using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombToss : MonoBehaviour {

	public GameObject bombPrefab;

	private Camera screen;
	private WaitForSeconds shortWait = new WaitForSeconds(0.25f);
	private Vector2 playerPosition;
	private Vector2 playerSize;
	public float speed = 5.0f;
	private GameObject bomb;
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

		bomb = GameObjectUtil.Instantiate(bombPrefab, new Vector3(playerPosition.x + (playerSize.x /2) + 5 , playerPosition.y, 0));
		bomb.GetComponent<InstantVelocity> ().velocity = direction.normalized * speed;
		shooting = true;
		yield return shortWait;
		shooting = false;
	}

	// Update is called once per frame
	void Update () {

		if (Input.GetKeyDown(KeyCode.Q))
		{
			Fire ();

		} 
	}

}
