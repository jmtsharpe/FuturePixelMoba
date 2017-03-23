using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByContact : MonoBehaviour {

	public GameManager gameManager;

	void Start ()
	{
		GameObject gameManagerObject = GameObject.FindWithTag ("GameManager");
		if (gameManagerObject != null) {

			gameManager = gameManagerObject.GetComponent <GameManager>();
		
		}
	}
	void OnTriggerEnter2D(Collider2D other) {
		if (gameObject.tag == "Zombie") {
			gameManager.Upscore (1);
		}
		GameObjectUtil.Destroy (other.gameObject);
		GameObjectUtil.Destroy (gameObject);
	}
}