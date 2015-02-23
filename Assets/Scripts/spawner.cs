using UnityEngine;
using System.Collections;

public class spawner : MonoBehaviour {

	public float[] xpositions = new float[9];
	public GameObject objectToSpawn;
	void SpawnObject() {
		Instantiate (objectToSpawn, new Vector3 (xpositions[Random.Range (0, xpositions.Length)], 3.6f, 0), Quaternion.identity);
	}

	// Use this for initialization
	void Start () {
			InvokeRepeating ("SpawnObject", 0, 1.0f);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
