using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explode : MonoBehaviour {
	public GameObject explosionPrefab;
	private GameObject explosion;

	public void BlowUp(){
		explosion = GameObjectUtil.Instantiate(explosionPrefab, new Vector3(gameObject.transform.position.x , gameObject.transform.position.y, 0));
		GameObjectUtil.Destroy (gameObject);
	}

}
