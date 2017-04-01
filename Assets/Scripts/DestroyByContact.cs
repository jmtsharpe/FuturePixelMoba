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
		if (other.GetComponent<MissileSeekTarget> ().target == gameObject) {
			
			HasHealth health = gameObject.GetComponent<HasHealth> ();
			if (health != null) {
			
				health.TakeDamage (other.GetComponent<Damage> ().GetDamage ());
			}
			GameObjectUtil.Destroy (other.gameObject);
		} else if (other.CompareTag ("Bomb")) {
			Debug.Log ("EXPLOSION SHOULD HAPPEN");
			other.GetComponent<Explode> ().BlowUp ();
		} else if (other.CompareTag ("Explosion")) {
			HasHealth health = gameObject.GetComponent<HasHealth> ();
			if (health != null) {
				health.TakeDamage (other.GetComponent<Damage> ().GetDamage ());
			}
		}
	}
}