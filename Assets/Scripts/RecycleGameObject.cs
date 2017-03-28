using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public interface IRecyle{

	void Restart();
	void Shutdown();

}

public class RecycleGameObject : MonoBehaviour {


	public delegate void OnDestroy();
	public event OnDestroy DestroyCallback;

	private List<IRecyle> recycleComponents;

	void Awake(){

		var components = GetComponents<MonoBehaviour> ();
		recycleComponents = new List<IRecyle> ();
		foreach (var component in components) {
			if(component is IRecyle){
				recycleComponents.Add (component as IRecyle);
			}
		}
	}


	public void Restart(){
		HasHealth health = gameObject.GetComponent<HasHealth> ();
		if (health) {
			health.Restart();
		}
		gameObject.SetActive (true);

		foreach (var component in recycleComponents) {
			component.Restart();
		}
	}

	public void Shutdown(){
		
		if (DestroyCallback != null) {
			DestroyCallback ();
		}

		gameObject.SetActive (false);

		foreach (var component in recycleComponents) {
			component.Shutdown();
		}
	}

}
