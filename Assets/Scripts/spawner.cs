using UnityEngine;
using System.Collections;

public class spawner : MonoBehaviour {

	public float[] xpositions = new float[9];
	public GameObject objectToSpawn;
	private float initialRate = 3.0f;
	public float changeFromInitialRate = 0.0f;
	private float spawnTime;
	private float lastCreated = Time.time;
	void SpawnObject() {
		Instantiate (objectToSpawn, new Vector3 (xpositions[Random.Range (0, xpositions.Length)], 3.6f, 0), Quaternion.identity);
	}

	// Use this for initialization
	void Start () {


	}
	

	// Update is called once per frame
	void Update () {
		spawnTime = initialRate - changeFromInitialRate;
		float now = Time.time;

		if (now - this.lastCreated > this.spawnTime) {
			this.SpawnObject ();
			this.lastCreated = now;
		}
		changeFromInitialRate += Time.deltaTime/100;
	}
}
