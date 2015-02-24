using UnityEngine;
using System.Collections;

public class LoadState : MonoBehaviour {
	public GameObject gameController;
	//public gameObject = GameObject.game;
	// Use this for initialization
	void Start () {
		//Reset timescale to 1.0 if it has been set to 0.0 in GameController
		Time.timeScale = 1.0f;

		//Instantiate GameController object if it has not been created yet
		GameObject gameControllerObject = GameObject.FindWithTag ("GameController");
		if (gameControllerObject == null)
		{
			Instantiate (gameController, new Vector3 (0, 0, 0), Quaternion.identity);
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
