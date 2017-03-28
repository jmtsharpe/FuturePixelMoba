using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class HasHealth : MonoBehaviour {
	public int maxHealth;
	public int health;
	public GameManager gameManager;

	void Start (){
		health = maxHealth;
		GameObject gameManagerObject = GameObject.FindWithTag ("GameManager");
		if (gameManagerObject != null) {

			gameManager = gameManagerObject.GetComponent <GameManager>();

		}
	}

	public void Restart(){
		Debug.Log ("Restarted");
		health = maxHealth;
	}

	public void TakeDamage(int damage){
		health -= damage;
		if (health <= 0) {
			if(gameObject.CompareTag("Zombie")){
				gameManager.Upscore (1);
			}
			GameObjectUtil.Destroy (gameObject);
				
		}
	}
}
