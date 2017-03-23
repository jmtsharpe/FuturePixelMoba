using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour {

	public GameObject bulletPrefab;

	private WaitForSeconds shortWait = new WaitForSeconds(0.25f);
	private Vector2 playerPosition;
	private Vector2 playerSize;
	private GameObject bullet;
	public bool shooting;

	void Awake() {
		playerSize = GetComponent<BoxCollider2D> ().size;
	}

	IEnumerator Fire() {
		bullet = GameObjectUtil.Instantiate(bulletPrefab, new Vector3(playerPosition.x + (playerSize.x /2) + 5 , playerPosition.y, 0));
		shooting = true;
		yield return shortWait;
		shooting = false;
	}

	// Update is called once per frame
	void Update () {


		if(Input.GetKeyDown("space")){
			playerPosition = GetComponent<Transform> ().position;
			StopCoroutine("Fire");
			StartCoroutine("Fire");
			//StopCoroutine("Fire");
		}
	}
}
