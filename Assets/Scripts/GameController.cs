using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameController : MonoBehaviour {
	public int gameScore = 0;
	public int playerLives = 3;
	private GameObject textGameObject;
	private Text scoreText;

	// Use this for initialization
	void Start () {

		gameScore = 0;
		DontDestroyOnLoad (this);

		textGameObject = GameObject.FindWithTag("scoreText");
		scoreText = textGameObject.GetComponent<Text> ();
	}
		
	// Update is called once per frame
	void Update () {
		this.scoreText.text = "Score:" + gameScore;

	}

	void SetScore() {

	}

	public void AddScore ( int newScore ) {
		gameScore += newScore;

	}

	public void KillPlayer () {
		playerLives -= 1;
		Time.timeScale = 0.0f;
		float resumeTime = Time.realtimeSinceStartup + 2;
		while (Time.realtimeSinceStartup < resumeTime)
		{
		}
		Invoke("WaitToRestart", 0.0f);

	}

	void WaitToRestart() {
        Application.LoadLevel(Application.loadedLevel);
    }
}


