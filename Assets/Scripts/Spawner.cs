using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {
	private float speedUp = 1; 
	public GameObject[] prefabs;
	public float delay = 30f;
	public bool active = true;
	public float shortDelay = 1f;

	// Use this for initialization
	void Start () {
		StartCoroutine (EnemyGenerator ());
	}

	IEnumerator EnemyGenerator(){

		yield return new WaitForSeconds (delay);

		if (active) {
			for (var i = 0; i < 5; i++) {

				Vector3 temp = new Vector3 (transform.position.x, (Screen.height / PixelPerfectCamera.pixelsToUnits) / 4, 0);
				var newTransform = transform;
				newTransform.position = temp;

				GameObjectUtil.Instantiate (prefabs [Random.Range (0, prefabs.Length)], newTransform.position);
				yield return new WaitForSeconds (shortDelay);
			}
		}

		StartCoroutine (EnemyGenerator ());

	}



}
