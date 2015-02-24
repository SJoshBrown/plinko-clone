using UnityEngine;
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
		if (collision.gameObject.tag == "Glove") {
			Destroy (this.gameObject);
			gameController.AddScore(1);
		} else if (collision.gameObject.tag == "bottom") {
			Destroy (this.gameObject);
			gameController.KillPlayer();
		}

	}

}
