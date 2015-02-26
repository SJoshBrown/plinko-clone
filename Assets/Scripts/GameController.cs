using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameController : MonoBehaviour {
	private int gameScore = 0;
	public int playerLives = 3;
	private GameObject textGameObject;
	private Text scoreText;
	public GameObject spawnerObject;
	private GameObject[] playerSprites = new GameObject[9];
	private Vector3 spritePosition;
	public GameObject xObject;
	private GameObject gameOverUI;
	// Use this for initialization
	void Start () {
		gameOverUI = GameObject.FindGameObjectWithTag("gameOverUI");
		gameOverUI.SetActive(false);

		gameScore = 0;
		playerSprites[0] = GameObject.FindGameObjectWithTag("playerSprite1");
		playerSprites[1] = GameObject.FindGameObjectWithTag("playerSprite2");
		playerSprites[2] = GameObject.FindGameObjectWithTag("playerSprite3");
		textGameObject = GameObject.FindWithTag("scoreText");
		scoreText = textGameObject.GetComponent<Text> ();
	}
		
	// Update is called once per frame
	void Update () {
		this.scoreText.text = "Score:" + gameScore;
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
		spritePosition = playerSprites [2 - playerLives].transform.position;
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
		gameOverUI.SetActive(true);
	}

	public void Restart(){
		Application.LoadLevel(Application.loadedLevel);
		Time.timeScale = 1.0f;
	}
}


