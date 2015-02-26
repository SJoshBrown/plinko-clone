using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameController : MonoBehaviour {
	public int gameScore = 0;
	public int playerLives = 3;
	private GameObject textGameObject;
	private Text scoreText;
	public GameObject spawnerObject;
	private GameObject[] playerSprites;
	private Vector3 spritePosition;
	public GameObject xObject;
	// Use this for initialization
	void Start () {

		gameScore = 0;
		DontDestroyOnLoad (this);
		playerSprites = GameObject.FindGameObjectsWithTag ("playerSprite");
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
		DestroyAllGameObjectsWithTag ("ball");
		DestroyAllGameObjectsWithTag ("ballPlaceholder");
		DestroyAllGameObjectsWithTag ("spawner");
		Instantiate (spawnerObject, new Vector3 (0.0f, 0.0f, 0.0f), Quaternion.identity);
		spritePosition = playerSprites [playerLives].transform.position;
		Instantiate (xObject, spritePosition, Quaternion.identity);
		if (playerLives <= 0)
			EndGame ();
	}

	void DestroyAllGameObjectsWithTag(string tag){
		GameObject[] gameObjects = GameObject.FindGameObjectsWithTag (tag);
		foreach (GameObject obj in gameObjects) {
			GameObject.Destroy (obj);
		}
	}

	void EndGame(){
		Time.timeScale = 0.0f;
	}
}


