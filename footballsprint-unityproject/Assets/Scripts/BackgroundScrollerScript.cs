using UnityEngine;
using System.Collections;

public class BackgroundScrollerScript : MonoBehaviour {

	public float leftLimit;
	public float spriteWidth;
	public Transform otherBG;
	public Transform mainCamera;

	void FixedUpdate() {
		if(transform.position.x < (mainCamera.position.x-leftLimit))
			transform.position = new Vector2(otherBG.position.x+spriteWidth, transform.position.y);
	}
}
