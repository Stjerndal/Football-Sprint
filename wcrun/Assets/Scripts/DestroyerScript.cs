using UnityEngine;
using System.Collections;

public class DestroyerScript : MonoBehaviour {

	public int playerEnterSceneNr = 0;
	public GameScreenController gameScreenController;

	void OnTriggerEnter2D(Collider2D other) {
		if(other.tag == "Player") {
			//Application.LoadLevel(playerEnterSceneNr);
			gameScreenController.GameOver();
			return;
		}

		if(other.tag == "SpawnGround") {
			return;
		}

		if(other.gameObject.transform.parent) {
			Destroy(other.gameObject.transform.parent.gameObject);
		}
		else {
			Destroy (other.gameObject);
		}

	}

}
