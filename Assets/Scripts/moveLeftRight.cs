using UnityEngine;
using System.Collections;

public class moveLeftRight : MonoBehaviour {

	public float speed;
	public float xMin;
	public float xMax;
	private float x;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {


		transform.Translate(Input.GetAxis("Horizontal") * speed,0,0);

		transform.position = new Vector3(
        Mathf.Clamp(transform.position.x, xMin, xMax),
        transform.position.y,
        transform.position.z
    );
	}
}
