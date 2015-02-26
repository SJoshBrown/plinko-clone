using UnityEngine;
using System.Collections;

public class DropBehavior : MonoBehaviour {
	
	// Update is called once per frame
	void Update () {
		if (this.gameObject.transform.position.y <= 3.425f)
		{
			this.gameObject.rigidbody2D.isKinematic = true;
		}
	}
}
