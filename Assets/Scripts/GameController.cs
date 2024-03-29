﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameController : MonoBehaviour {
	public int playerLives = 3;
	public GameObject spawnerObject;
	public GameObject xObject;
	public AudioClip killPlayerSound;
	public AudioClip endGameSound;
	public float volume;

	private int gameScore = 0;
	private Text scoreText;
	private GameObject[] playerSprites = new GameObject[3];
	private Vector3 spritePosition;
	private GameObject gameOverUI;

	// Use this for initialization
	void Start () {
		Time.timeScale = 1.0f;

		Instantiate (spawnerObject, new Vector3 (0.0f, 0.0f, 0.0f), Quaternion.identity);

		gameOverUI = GameObject.FindGameObjectWithTag("gameOverUI");
		gameOverUI.SetActive(false);

		gameScore = 0;

		playerSprites[0] = GameObject.FindGameObjectWithTag("playerSprite1");
		playerSprites[1] = GameObject.FindGameObjectWithTag("playerSprite2");
		playerSprites[2] = GameObject.FindGameObjectWithTag("playerSprite3");

		scoreText = GameObject.FindWithTag("scoreText").GetComponent<Text> ();
	}
		
	// Update is called once per frame
	void Update () {
		scoreText.text = "Score:" + gameScore;
	}

	public void AddScore ( int newScore ) {
		gameScore += newScore;
	}

	public void KillPlayer () {
		playerLives -= 1;
		DestroyAllGameObjectsWithTag (new string[] {"ball","ballPlaceholder","spawner"});
		Instantiate (spawnerObject, new Vector3 (0.0f, 0.0f, 0.0f), Quaternion.identity);
		spritePosition = playerSprites [playerLives].transform.position;
		Instantiate (xObject, spritePosition, Quaternion.identity);
		if (playerLives <= 0) {
			AudioSource.PlayClipAtPoint (endGameSound, transform.position, volume);
			EndGame ();
		}
		else
			AudioSource.PlayClipAtPoint (killPlayerSound ,transform.position, volume);
	}

	void DestroyAllGameObjectsWithTag(string[] tags){
		foreach (string tag in tags)
		{
			GameObject[] gameObjects = GameObject.FindGameObjectsWithTag (tag);
			foreach (GameObject obj in gameObjects) 
			{
				GameObject.Destroy (obj);
			}
		}
	}

	void EndGame(){
		Time.timeScale = 0.0f;
		gameOverUI.SetActive(true);
	}

	public void Restart(){
		Application.LoadLevel(Application.loadedLevel);
		Time.timeScale = 1.0f;
	}

	public void QuitGame(){
		Application.Quit ();
	}
}


