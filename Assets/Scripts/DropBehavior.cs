using UnityEngine;
using System.Collections;

public class DropBehavior : MonoBehaviour {
	
	// Update is called once per frame
	void Update () {
		if (gameObject.transform.position.y <= 3.425f)
		{
			gameObject.rigidbody2D.isKinematic = true;
		}
	}
}
