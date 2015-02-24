using UnityEngine;
using System.Collections;

public class spawner : MonoBehaviour {

	public float[] xpositions = new float[9];
	public GameObject objectToSpawn;
	public float initialRate = 3.0f;
	private float changeFromInitialRate = 0.0f;
	public float spawnTime;
	private float lastCreated = Time.time;
	private float now = Time.time;
	public float minimumInterval = 0.0f;

	//Mathf.Clamp(changeFromInitialRate, 0.0f, 2.0f);
	void SpawnObject() {
		Instantiate (objectToSpawn, new Vector3 (xpositions[Random.Range (0, xpositions.Length)], 3.6f, 0), Quaternion.identity);
	}

	// Use this for initialization
	void Start () {
		SpawnObject();

	}
	

	// Update is called once per frame
	void Update () {

		spawnTime = initialRate - Mathf.Clamp(changeFromInitialRate, 0.0f, initialRate - minimumInterval);
		now = Time.time;

		if (now - this.lastCreated > this.spawnTime) {
			this.SpawnObject ();
			this.lastCreated = now;
		}
		changeFromInitialRate += Time.deltaTime/150;
	}
}
