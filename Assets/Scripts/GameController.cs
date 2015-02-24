using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {
	public int gameScore = 0;
	public int playerLives = 0;
	
	// Use this for initialization
	void Start () {
		gameScore = 0;
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
	}
}
