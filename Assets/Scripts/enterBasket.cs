﻿using UnityEngine;
using System.Collections;

public class enterBasket : MonoBehaviour {

	public GameController gameController;

	// Use this for initialization
	void Start () {
		GameObject gameControllerObject = GameObject.FindWithTag ("GameController");
		if (gameControllerObject != null)
		{
			gameController = gameControllerObject.GetComponent <GameController>();
		}
	}
	

	void OnCollisionEnter2D(Collision2D collision) {
		//Debug.Log ("Collision detected", collision.gameObject);
		if (collision.gameObject.tag == "Glove") {
			Destroy (this.gameObject);
			gameController.AddScore(1);
			Debug.Log (gameController.gameScore);
		} else if (collision.gameObject.tag == "bottom") {
			Destroy (this.gameObject);
		}

	}

	// Update is called once per frame
	void Update () {
	
	}
}
