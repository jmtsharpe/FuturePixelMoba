using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

	public GameObject playerPrefab;

	private bool gameStarted;
	private TimeManager timeManager;
	private GameObject player;
	private GameObject floor;
	private Spawner spawner;
	public int score;
	public Text scoreText;
	public Text endScore;
	public GameObject startScreen;


	void Awake() {
		score = 0;
		UpdateScore ();
		startScreen = GameObject.FindWithTag ("Start Screen");
		startScreen.SetActive (false);
		floor = GameObject.Find ("Foreground");
		spawner = GameObject.Find ("Spawner").GetComponent<Spawner> ();
		timeManager = GetComponent<TimeManager> ();
	}

	// Use this for initialization
	void Start () {
		
		score = 0;
		UpdateScore ();
		var floorHeight = floor.transform.localScale.y;

		var pos = floor.transform.position;
		pos.x = 0;
		pos.y = -((Screen.height / PixelPerfectCamera.pixelsToUnits) / 2) + (floorHeight / 2);
		floor.transform.position = pos;

		gameStarted = true;
		ResetGame ();

	}
	
	// Update is called once per frame
	void Update () {
		if (!gameStarted && Time.timeScale == 0) {

		}
	}

	void OnPlayerKilled(){
		print ("player killed");

		var playerDestroyScript = player.GetComponent<RecycleGameObject> ();
		playerDestroyScript.DestroyCallback -= OnPlayerKilled;

		StopCoroutine ("Respawn");
		StartCoroutine ("Respawn");
	}

	IEnumerator Respawn(){
		yield return new WaitForSeconds (5);
		ResetGame ();
	}

	public void Upscore (int val){
		print ("score updated");
		score += val;
		UpdateScore ();
		print (scoreText.text);
	}

	public void UpdateScore(){
		scoreText.text = "Score: " + score;
	}
	void ResetGame() {
		score = 0;
		UpdateScore ();


		player = GameObjectUtil.Instantiate(playerPrefab, new Vector3(-375, (Screen.height/PixelPerfectCamera.pixelsToUnits) / 10, 0));
		var camera = GameObject.Find("Main Camera");
		camera.transform.position = new Vector3 (-375, 0, -10);
	
		var playerDestroyScript = player.GetComponent<RecycleGameObject> ();
		playerDestroyScript.DestroyCallback += OnPlayerKilled;
		gameStarted = true;
		spawner.active = true;
	}
}
