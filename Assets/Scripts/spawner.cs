using UnityEngine;
using System.Collections;

public class spawner : MonoBehaviour {

	public float[] xpositions = new float[9];
	public GameObject objectToSpawn;
	public GameObject placeholderObjectToSpawn;
	public float initialRate = 3.0f;
	private float changeFromInitialRate = 0.0f;
	public float spawnTime;
	private float lastCreated = Time.time;
	private float now = Time.time;
	public float minimumInterval = 0.0f;
	private Transform placeholderPosition;

	//Mathf.Clamp(changeFromInitialRate, 0.0f, 2.0f);
	void SpawnObject() {
		//Instantiate (placeholderObjectToSpawn, new Vector3 (xpositions[Random.Range (0, xpositions.Length)], 3.6f, 0), Quaternion.identity);

		GameObject existingPlaceholder = GameObject.FindWithTag ("ballPlaceholder");
		placeholderPosition = existingPlaceholder.transform;
		Instantiate (objectToSpawn, new Vector3 (placeholderPosition.position.x, placeholderPosition.position.y, placeholderPosition.position.z), Quaternion.identity);
		Destroy (existingPlaceholder);
		Instantiate (placeholderObjectToSpawn, new Vector3 (xpositions[Random.Range (0, xpositions.Length)], 3.65f, 0), Quaternion.identity);
	}

	// Use this for initialization
	void Start () {
		Instantiate (placeholderObjectToSpawn, new Vector3 (xpositions[Random.Range (0, xpositions.Length)], 3.65f, 0), Quaternion.identity);

	}
	

	// Update is called once per frame
	void Update () {

		spawnTime = initialRate - Mathf.Clamp(changeFromInitialRate, 0.0f, initialRate - minimumInterval);
		now = Time.time;

		if (now - this.lastCreated > this.spawnTime) {
			this.SpawnObject ();
			this.lastCreated = now;
		}
		changeFromInitialRate += Time.deltaTime/75;
	}
}
