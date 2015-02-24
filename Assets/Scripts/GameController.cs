using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {
	public int gameScore = 0;
	public int playerLives = 3;
	//private static created = false;
	// Use this for initialization
	void Start () {
		//if (created)
		gameScore = 0;
		DontDestroyOnLoad (this);
		
	}
		
	// Update is called once per frame
	void Update () {

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


