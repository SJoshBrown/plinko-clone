using UnityEngine;
using System.Collections;

public class DropBehavior : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (this.gameObject.transform.position.y <= 3.425f)
		{
			Debug.Log("< -2");
			this.gameObject.rigidbody2D.isKinematic = true;
		}
	}
}
