using UnityEngine;
using System.Collections;

public class moveLeftRight : MonoBehaviour {

	public float speed;
	public float xMin;
	public float xMax;
	private float x;
	
	// Update is called once per frame
	void Update () {
		transform.Translate(Input.GetAxis("Horizontal") * speed * Time.deltaTime,0,0);
		
		transform.position = new Vector3(
        	Mathf.Clamp(transform.position.x, xMin, xMax),
        	transform.position.y,
        	transform.position.z
  			);
	}
}
