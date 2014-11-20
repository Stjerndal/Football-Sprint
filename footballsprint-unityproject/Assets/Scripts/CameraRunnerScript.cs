using UnityEngine;
using System.Collections;

public class CameraRunnerScript : MonoBehaviour {

	public Transform player;
	public int playerOffset = 6;
	public float yCenter = 0;

	public void setChar(Transform newChar) {
		player = newChar;
	}

	// Update is called once per frame
	void Update () {
		transform.position = new Vector3(player.position.x + playerOffset, yCenter, -10);
	}

	public void forceUpdate() {
		transform.position = new Vector3(player.position.x + playerOffset, yCenter, -10);
	}

}
