using UnityEngine;
using System.Collections;

public class spawner : MonoBehaviour {

	private Transform placeholderPosition;
	//private float changeFromInitialRate = 0.0f;
	private float lastCreated;
	private float now;
	private int ballsDropped = 0;

	//public for testing
	public float spawnTime;

	public float[] xpositions = new float[9];
	public GameObject objectToSpawn;
	public GameObject placeholderObjectToSpawn;
	public float initialRate = 3.0f;
	public float minimumSpawnTime = 0.0f;
	public float timeDecreaseAmount = 0.0f;
	public int increaseInterval = 10;


	void SpawnObject() {

		GameObject existingPlaceholder = GameObject.FindWithTag ("ballPlaceholder");
		placeholderPosition = existingPlaceholder.transform;
		Instantiate (objectToSpawn, new Vector3 (placeholderPosition.position.x, placeholderPosition.position.y, placeholderPosition.position.z), Quaternion.identity);
		Destroy (existingPlaceholder);
		Instantiate (placeholderObjectToSpawn, new Vector3 (xpositions[Random.Range (0, xpositions.Length)], 3.65f, 0), Quaternion.identity);
		ballsDropped += 1;
		if (ballsDropped % increaseInterval == 0) {
			spawnTime -= timeDecreaseAmount;
		}
	}

	// Use this for initialization
	void Start () {
		Instantiate (placeholderObjectToSpawn, new Vector3 (xpositions[Random.Range (0, xpositions.Length)], 3.65f, 0), Quaternion.identity);
		this.lastCreated = Time.time - (initialRate - 1.0f);
		ballsDropped += 1;
		spawnTime = initialRate;
	}
	

	// Update is called once per frame
	void Update () {



		//spawnTime = initialRate - Mathf.Clamp(changeFromInitialRate, 0.0f, initialRate - minimumInterval);
		now = Time.time;

		if (now - this.lastCreated > Mathf.Clamp(this.spawnTime, minimumSpawnTime, initialRate)) {
			this.SpawnObject ();
			this.lastCreated = now;
		}
		//changeFromInitialRate += Time.deltaTime/50;
	}
}
