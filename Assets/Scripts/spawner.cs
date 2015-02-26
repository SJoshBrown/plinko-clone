using UnityEngine;
using System.Collections;

public class spawner : MonoBehaviour {

	private Transform placeholderPosition;
	private float lastCreated;
	private float now;
	private int ballsDropped = 0;
	private float spawnTime;

	public float[] xpositions = new float[9];
	public GameObject objectToSpawn;
	public GameObject placeholderObjectToSpawn;
	public float initialRate = 3.0f;
	public float minimumSpawnTime = 0.0f;
	public float timeDecreaseAmount = 0.0f;
	public int increaseInterval = 10;

	// Use this for initialization
	void Start () {
		Instantiate (placeholderObjectToSpawn, new Vector3 (xpositions[Random.Range (0, xpositions.Length)], 3.65f, 0), Quaternion.identity);
		ballsDropped += 1;

		//Set the initial time before dropping the first ball to 1 second regardless of initialRate
		this.lastCreated = Time.time - (initialRate - 1.0f);
		
		spawnTime = initialRate;
	}
	

	// Update is called once per frame
	void Update () {
		now = Time.time;

		//Spawn new ball if enough time has passed since one was last created
		if (now - this.lastCreated > Mathf.Clamp(this.spawnTime, minimumSpawnTime, initialRate)) {
			this.SpawnObject ();
			this.lastCreated = now;
		}
	}

	//Destroy placeholder and create object in its place
	//Create new placeholder at a random location
	//Increase ballsDropped by one
	//Decrease spawn rate if interval is met
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
}
