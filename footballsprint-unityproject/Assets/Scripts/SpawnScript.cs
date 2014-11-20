using UnityEngine;
using System.Collections;

public class SpawnScript : MonoBehaviour {

	public GameObject[] obj;
	//Spawn randomly between 1 and 2 seconds.
	public float spawnMin = 1f;
	public float spawnMax = 2f;

	public bool running = true;

	public float yOffset;

	float time;
	float randomTime;

	// Use this for initialization
	void Start () {
		//Spawn ();
		randomTime = 0f;
	}
	
	/*public void Spawn() {
		if(running) {
			Instantiate (obj[Random.Range(0, obj.Length)], transform.position, Quaternion.identity);
			if(running)
				Invoke ("Spawn", Random.Range(spawnMin, spawnMax));
		}
	}*/

	public void Update() {
		if(running) {
			time += Time.deltaTime;
			if((time >= randomTime) || time >= spawnMax) {
				Instantiate (obj[Random.Range(0, obj.Length)], new Vector2(transform.position.x, (transform.position.y+yOffset)), Quaternion.identity);
				randomTime = Random.Range(spawnMin, spawnMax);
				time = 0f;
			}
		} 
	}

	public void Reset() {
		time = spawnMax;
		running = true;
	}

}
