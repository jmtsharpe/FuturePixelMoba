﻿using System.Collections;
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


	void Awake() {
		score = 0;
		UpdateScore ();
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

		spawner.active = false;
		Time.timeScale = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if (!gameStarted && Time.timeScale == 0) {

			if (Input.anyKeyDown) {
				timeManager.ManipulateTime (1, 1f);
				ResetGame ();
			}
		}
	}

	void OnPlayerKilled(){
		print ("player killed");
		spawner.active = false;

		var playerDestroyScript = player.GetComponent<RecycleGameObject> ();
		playerDestroyScript.DestroyCallback -= OnPlayerKilled;

		player.GetComponent<Rigidbody2D> ().velocity = Vector2.zero;
		timeManager.ManipulateTime (0, 5.5f);
		gameStarted = false;
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
		spawner.active = true;

		player = GameObjectUtil.Instantiate(playerPrefab, new Vector3(0, (Screen.height/PixelPerfectCamera.pixelsToUnits) / 2 + 100, 0));
	
		var playerDestroyScript = player.GetComponent<RecycleGameObject> ();
		playerDestroyScript.DestroyCallback += OnPlayerKilled;
		gameStarted = true;
	}
}