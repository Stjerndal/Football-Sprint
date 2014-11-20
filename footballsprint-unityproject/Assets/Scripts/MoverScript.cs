using UnityEngine;
using System.Collections;

public class MoverScript : MonoBehaviour {

	public Vector2 speed;

	// Use this for initialization
	void Start () {
		rigidbody2D.velocity = speed;
	}
	
	public void StopMoving() {
		rigidbody2D.velocity = new Vector2(0f, 0f);
	}

	public void Restart(Vector2 spawnPos) {
		transform.position = spawnPos;
		rigidbody2D.velocity = speed;
	}
}
